var table = null;
var zip = new JSZip();

$(document).ready(function () {
    LoadInitialCreateData();
});

function LoadInitialCreateData() {
    debugger;
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
            //{ title: "Reimbursement Status", data: "ReimbursementStatus" },
            {
                title: "Request Date",
                data: "RequestDate",
                render: function (jsonDate) {
                    var date = moment(jsonDate).format("DD/MM/YYYY");
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
                        "<button class='btn btn-outline-danger' data-placement = 'right' title='Reject' onclick='ShowReject(" + meta.row + ")'><i class='fa fa-lg fa-window-close'></i></button>"

                }
            }
        ],
        success: function (res) {
            console.log(res);
        }
    });

}
var tableApprovedByManager = {
    create: function () {
        debugger;
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
        debugger;
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

function ShowReject(id) {
    $('#Id').val(table.row(id).data().Id);
    $('#EmployeeId').val(table.row(id).data().EmployeeId);
    $('#rejectReason').val('');
    $('#exampleModalCenterEdit').modal('show');
}

function Approve(idx) {
    //debugger;
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
            table.ajax.reload(null, false);
            tableManager.create();
            tableApprovedByManager.create();

        } else {
            Swal.fire('Error', result.Item2, 'error');
        }
    });
}
function Reject() {
    var rejectVM = {
        Id: $('#Id').val(),
        EmployeeId: $('#EmployeeId').val(),
        RejectReason: $('#rejectReason').val()
    }
    $.ajax({
        url: "/ManagerApproval/UpdateReject/",
        data: rejectVM,
        type: "POST",
        dataType: "JSON",
    }).then((result) => {
        debugger;
        if (result.Item1.StatusCode == 200) {
            Swal.fire('Success', result.Item2, 'success');
            table.ajax.reload(null, false);
            $('#exampleModalCenterEdit').modal('hide');
        } else {
            Swal.fire('Error', result.Item2, 'error');
        }
    });
}

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
};
/* Custom filtering function which will filter data in column four between two values */

$(document).ready(function () {
    $.fn.dataTable.ext.search.push(
        function (settings, data, dataIndex) {
            var min = $('#min').datepicker("getDate");
            var max = $('#max').datepicker("getDate");
            var startDate = new Date(data[4]);
            if (min == null && max == null) { return true; }
            if (min == null && startDate <= max) { return true; }
            if (max == null && startDate >= min) { return true; }
            if (startDate <= max && startDate >= min) { return true; }
            return false;
        }
    );


    $("#min").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });
    $("#max").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });
    var table = $('#MydataTable').DataTable();

    // Event listener to the two range filtering inputs to redraw on input
    $('#min, #max').change(function () {

        table.draw();
    });
});
