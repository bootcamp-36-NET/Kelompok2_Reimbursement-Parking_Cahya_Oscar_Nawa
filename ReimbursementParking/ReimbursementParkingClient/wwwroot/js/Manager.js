var tableManager = {
    create: function () {
        if ($.fn.DataTable.isDataTable('#MydataTable')) {
            $('#MydataTable').DataTable().clear();
            $('#MydataTable').DataTable().destroy();
        }
        $.ajax({
            url: '/Managers/LoadApprovalManager/',
            type: 'get',
            contentType: 'application/json',
            success: function (res, status, xhr) {
                if (xhr.status == 200 || xhr.status == 201) {
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
                            { title: "Content", data: "Content" },
                            {
                                title: "Action", data: null,
                                "sortable": false,
                                render: function (data, type, row) {
                                    return "<button class='btn btn-outline-warning' data-placement = 'left' title='Edit' onclick=formManager.setApprove('" + data.Id + "')><i class='fa fa-lg fa-edit'></i></button>"
                                        + "&nbsp;" +
                                        "<button class='btn btn-outline-danger' data-placement = 'right' title='Delete' onclick=formManager.setReject('" + data.Id + "')><i class='fa fa-lg fa-trash'></i></button>"

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