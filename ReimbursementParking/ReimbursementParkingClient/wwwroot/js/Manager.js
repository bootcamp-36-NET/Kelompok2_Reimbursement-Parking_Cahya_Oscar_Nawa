var tableManager = {
    create: function () {
        if ($.fn.DataTable.isDataTable('#MydataTable')) {
            $('#MydataTable').DataTable().clear();
            $('#MydataTable').DataTable().destroy();
        }
        $.ajax({
            url: '/Managers/LoadApprovalManager',
            type: 'get',
            contentType: 'application/json',
            success: function (res, status, xhr) {
                //debugger;
                if (xhr.status == 200) {
                    $('#MydataTable').DataTable({
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
                            //{ title: "Content", data: "Content" },
                            {
                                title: "Action", data: null,
                                "sortable": false,
                                render: function (data, type, row) {
                                    return "<button type='button' class='btn btn-outline-success' data-placement = 'left' title='Approve' onclick=formManager.setApprove('" + data.Id + "')><i class='fa fa-lg fa-check'></i></button>"
                                        + "&nbsp;" +
                                        "<button class='btn btn-outline-danger' data-placement = 'right' title='Reject' onclick=formManager.setReject('" + data.Id + "')><i class='fa fa-lg fa-window-close'></i></button>"

                                }
                            }
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

var tableApprovedByManager = {
    create: function () {
        if ($.fn.DataTable.isDataTable('#Mydata')) {
            $('#Mydata').DataTable().clear();
            $('#Mydata').DataTable().destroy();
        }
        $.ajax({
            url: '/Managers/LoadApprovedByManager',
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
var tableRejectedByManager = {
    create: function () {
        if ($.fn.DataTable.isDataTable('#MydataReject')) {
            $('#MydataReject').DataTable().clear();
            $('#MydataReject').DataTable().destroy();
        }
        $.ajax({
            url: '/Managers/LoadRejectedByManager',
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
var formManager = {
    setApprove: function (Id) {
        //var statusVM = new Object();
        //statusVM.StatusId = 3;
        var statusVM = {
            StatusId: 3,
            Id: Id
        }
        //debugger;
        $.ajax({
            url: '/managers/Update/' + Id,
            type: 'post',
            //contentType: 'application/json',
            dataType: 'json',
            data: { statusVM },
            success: function (res, status, xhr) {
                //debugger;
                if (xhr.status == 200 || xhr.status == 201) {
                    $('.swalDefaultSuccess').click(function () {
                        Toast.fire({
                            icon: 'success',
                            title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                        })
                    });
                    tableManager.create();
                    tableApprovedByManager.create();
                    toastr.success('Request has been approved.');
                } else {
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
            url: '/managers/GetById/' + editD,
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
            url: '/managers/UpdateReject/' + editD,
            method: 'post',
            //contentType: 'application/json',
            dataType: 'json',
            data: statusVM,
            success: function (res, status, xhr) {
                if (xhr.status == 200 || xhr.status == 201) {
                    tableManager.create();
                    tableRejectedByManager.create();
                    $('#exampleModalCenterEdit').modal('hide');
                    toastr.success('Request has been rejected.');
                } else {
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