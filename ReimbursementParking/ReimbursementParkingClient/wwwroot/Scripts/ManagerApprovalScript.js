var table = null;
var zip = new JSZip();

$(document).ready(function () {
    LoadInitialCreateData();
});

function LoadInitialCreateData() {
    table = $('#MydataTable').DataTable({
        ajax: {
            url: "/ManagerApproval/LoadApprovalManager",
            dataSrc: "",
            cache: false,
            type: "GET",
            dataType: "JSON"
        },
        columns: [
            {
                title: "No", data: null, render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { title: "Employee ID", data: "EmployeeId" },
            { title: "Reimbursement Status", data: "ReimbursementStatus" },
            {
                title: "Request Date",
                data: "RequestDate",
                render: function (jsonDate) {
                    var date = moment(jsonDate).format("DD MMMM YYYY");
                    return date;
                }
            },
            { title: "Plat Number", data: "PLATNumber" },
            { title: "Vehicle Type", data: "VeicleType" },
            { title: "Payment Type", data: "PaymentType" },
            { title: "Total Price", data: "TotalPrice" },
            { title: "Vehicle Owner", data: "VehicleOwner" },
            { title: "Parking Name", data: "ParkingName" },
            { title: "Parking Address", data: "ParkingAddress" },
            {
                title: "File Data",
                data: "Id",
                render: function (data, type, row, meta) {
                    return '<Button class="btn btn-outline-primary" onclick="return DownloadFolder(' + row.Id + ')"><i class="fa fa-lg fa-file-download"></i></button>';
                },
                "sortable": false,
                "oderable": false
            },
            {
                title: "Action", data: null,
                "sortable": false,
                render: function (data, type, row, meta) {
                    return '<Button class="btn btn-outline-success" title="Approve" onclick="return Approve(' + meta.row + ')"><i class="fa fa-lg fa-check"></i></button>'
                        + "&nbsp;" +
                        "<button class='btn btn-outline-danger' data-placement = 'right' title='Reject' onclick=formManager.setReject('" + data.Id + "')><i class='fa fa-lg fa-window-close'></i></button>"

                }
            }
        ],
        success: function (res) {
            console.log(res);
        }
    });

}

function ShowReject(id) {
    $('#Id').val(id);
    $('#Reason').val('');
    $('#rejectModal').modal('show');
}

function Approve(idx) {
    debugger;
    var approveVM = {
        Id: table.row(idx).data().Id,
        EmployeeId: table.row(idx).data().EmployeeId
    };
    $.ajax({
        url: "/ManagerApproval/ApproveRequest",
        type: "POST",
        dataType: "JSON",
        data: approveVM
    }).then((result) => {
        if (result.Item1.StatusCode == 200) {
            Swal.fire('Success', result.Item2, 'success');

        } else {
            Swal.fire('Error', result.Item2, 'error');
        }
        table.ajax.reload(null, false);
    });
}

var tableApprovedByManager = {
    create: function () {
        if ($.fn.DataTable.isDataTable('#Mydata')) {
            $('#Mydata').DataTable().clear();
            $('#Mydata').DataTable().destroy();
        }
        $.ajax({
            url: '/ManagerApproval/LoadApprovedByManager',
            type: 'get',
            contentType: 'application/json',
            success: function (res, status, xhr) {
                if (xhr.status == 200) {
                    $('#Mydata').DataTable({
                        dom: 'Bfrtip',
                        buttons: [
                            {
                                extend: 'copyHtml5',
                                text: '<i class="fa fa-file"></i>',
                                titleAttr: 'Copy',
                                className: 'btn btn-outline-warning'
                            },
                            {
                                extend: 'csv',
                                text: '<i class="fa fa-file-csv"></i>',
                                titleAttr: 'CSV',
                                className: 'btn btn-outline-info'
                            },
                            {
                                extend: 'excel',
                                text: '<i class="fa fa-file-excel"></i>',
                                titleAttr: 'Excel',
                                filename: 'Division List',
                                className: 'btn btn-outline-success'
                            },
                            {
                                extend: 'pdf',
                                text: '<i class="fa fa-file-pdf"></i>',
                                titleAttr: 'Pdf',
                                className: 'btn btn-outline-danger'
                            },
                            {
                                extend: 'print',
                                autoPrint: false,
                                text: '<i class="fa fa-print"></i>',
                                titleAttr: 'Print',
                                className: 'btn btn-outline-warning'
                            },

                        ],
                        data: res,
                        "columnDefs": [
                            { "orderable": false, "targets": 4 }
                        ],
                        columns: [
                            {
                                title: "No", data: null, render: function (data, type, row, meta) {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                            },
                            { title: "Employee ID", data: "EmployeeId" },
                            { title: "Reimbursement Status", data: "ReimbursementStatus" },
                            {
                                title: "Request Date",
                                data: "RequestDate",
                                render: function (jsonDate) {
                                    var date = moment(jsonDate).format("DD MMMM YYYY");
                                    return date;
                                }
                            },
                            { title: "Plat Number", data: "PLATNumber" },
                            { title: "Vehicle Type", data: "VeicleType" },
                            { title: "Payment Type", data: "PaymentType" },
                            { title: "Total Price", data: "TotalPrice" },
                            { title: "Vehicle Owner", data: "VehicleOwner" },
                            { title: "Parking Name", data: "ParkingName" },
                            { title: "Parking Address", data: "ParkingAddress" },
                            { title: "Content", data: "Content" },                            
                        ]
                    });
                } else {
                }
            },
            erorrr: function (err) {
                console.log(err);
            }
        });
    }
};
var tableRejectedByManager = {
    create: function () {
        if ($.fn.DataTable.isDataTable('#MydataReject')) {
            $('#MydataReject').DataTable().clear();
            $('#MydataReject').DataTable().destroy();
        }
        $.ajax({
            url: '/ManagerApproval/LoadRejectedByManager',
            type: 'get',
            contentType: 'application/json',
            success: function (res, status, xhr) {
                if (xhr.status == 200) {
                    $('#MydataReject').DataTable({
                        dom: 'Bfrtip',
                        buttons: [
                            {
                                extend: 'copyHtml5',
                                text: '<i class="fa fa-file"></i>',
                                titleAttr: 'Copy',
                                className: 'btn btn-outline-warning'
                            },
                            {
                                extend: 'csv',
                                text: '<i class="fa fa-file-csv"></i>',
                                titleAttr: 'CSV',
                                className: 'btn btn-outline-info'
                            },
                            {
                                extend: 'excel',
                                text: '<i class="fa fa-file-excel"></i>',
                                titleAttr: 'Excel',
                                filename: 'Division List',
                                className: 'btn btn-outline-success'
                            },
                            {
                                extend: 'pdf',
                                text: '<i class="fa fa-file-pdf"></i>',
                                titleAttr: 'Pdf',
                                className: 'btn btn-outline-danger'
                            },
                            {
                                extend: 'print',
                                autoPrint: false,
                                text: '<i class="fa fa-print"></i>',
                                titleAttr: 'Print',
                                className: 'btn btn-outline-warning'
                            },

                        ],
                        data: res,
                        "columnDefs": [
                            { "orderable": false, "targets": 4 }
                        ],
                        columns: [
                            {
                                title: "No", data: null, render: function (data, type, row, meta) {
                                    return meta.row + meta.settings._iDisplayStart + 1;
                                }
                            },
                            { title: "Employee ID", data: "EmployeeId" },
                            { title: "Reimbursement Status", data: "ReimbursementStatus" },
                            {
                                title: "Request Date",
                                data: "RequestDate",
                                render: function (jsonDate) {
                                    var date = moment(jsonDate).format("DD MMMM YYYY");
                                    return date;
                                }
                            },
                            { title: "Plat Number", data: "PLATNumber" },
                            { title: "Vehicle Type", data: "VeicleType" },
                            { title: "Payment Type", data: "PaymentType" },
                            { title: "Total Price", data: "TotalPrice" },
                            { title: "Vehicle Owner", data: "VehicleOwner" },
                            { title: "Parking Name", data: "ParkingName" },
                            { title: "Parking Address", data: "ParkingAddress" },
                            { title: "Reason", data: "RejectReason" },
                            //{ title: "Content", data: "Content" },                            
                        ]
                    });
                } else {
                }
            },
            erorrr: function (err) {
                console.log(err);
            }
        });
    }
};
var Id;
var EmployeeId;
var formManager = {
    setApprove: function (Idx) {
        debugger;
        var approveVM = {
            Id: Idx,
            EmployeeId: $('#MydataTable').DataTable({})
        };
        $.ajax({
            url: '/ManagerApproval/ApproveRequest/' + Id,
            type: 'post',
            dataType: 'json',
            data: approveVM,
            success: function (res, status, xhr) {
                debugger;
                if (res.Item1.StatusCode == 200 || res.Item1.StatusCode == 201) {
                    Swal.fire('Success', res.Item2, 'success');
                    tableManager.create();
                    tableApprovedByManager.create();
                    //toastr.success('Request has been approved.');
                } else {
                    Swal.fire('Error', res.Item2, 'error');
                }
            },
            erorr: function (err) {
                console.log(err);
            }
        });
    }, setReject: function (editD) {
        editReject = editD; // new, supaya id bisa dibawa ke fungsi editForm
        //console.log(editD);
        $.ajax({
            url: '/ManagerApproval/GetById/' + editD,
            method: 'get',
            contentType: 'application/json',
            dataType: 'json',
            success: function (res, status, xhr) {
                if (xhr.status == 200 || xhr.status == 201) {
                    $('#exampleModalCenterEdit').modal('show');
                } else {

                }
            },
            erorr: function (err) {
                console.log(err);
            }
        });


    }, editSaveRejection: function (editD) {
        debugger;
        editReject = editD;
        var statusVM = {
            RejectReason: document.getElementById("rejectReason").value,
            StatusId: 5,
            Id: editD
        }
        $.ajax({
            url: '/ManagerApproval/UpdateReject/' + editD,
            method: 'post',
            //contentType: 'application/json',
            dataType: 'json',
            data: statusVM,
            success: function (res, status, xhr) {
                if (xhr.status == 200 || xhr.status == 201) {
                    Swal.fire('Success', res.Item2, 'success');
                    tableManager.create();
                    tableRejectedByManager.create();
                    $('#exampleModalCenterEdit').modal('hide');
                    //toastr.success('Request has been rejected.');
                } else {
                    Swal.fire('Error', res.Item2, 'error');
                }
            },
            erorr: function (err) {
                console.log(err);
            }
        });
    }
};
var editReject;
$("#btn-reject").click(function () {
    formManager.editSaveRejection(editReject);
});
function DownloadFolder(Id) {
    $.ajax({
        url: "/ManagerApproval/DownloadFolder/" + Id,
        data: { Id: Id },
        cache: false,
        type: "GET",
        dataType: "JSON",
        success: function (response) {
            var fileName = response.Item2.Name;
            var sampleArr = base64ToArrayBuffer(response.Item2.Content);
            saveByteArray(fileName, sampleArr);
        },
    }).then((result) => {
        if (result.Item1.StatusCode == 200) {

        } else {
            Swal.fire('Error', result.Item2, 'error');
        }
    });
}

function saveByteArray(reportName, byte) {
    var blob = new Blob([byte]);
    var link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    var fileName = reportName + ".zip";
    link.download = fileName;
    link.click();
}

function base64ToArrayBuffer(base64) {
    var binaryString = window.atob(base64);
    var binaryLen = binaryString.length;
    var bytes = new Uint8Array(binaryLen);
    for (var i = 0; i < binaryLen; i++) {
        var ascii = binaryString.charCodeAt(i);
        bytes[i] = ascii;
    }
    return bytes;
}
