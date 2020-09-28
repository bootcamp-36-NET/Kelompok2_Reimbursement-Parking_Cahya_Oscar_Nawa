var table = null;
var arrDepart = [];

$(document).ready(function () {
    debugger;
    table = $('#requestReimbursement').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/ViewRequest/LoadRequest",
            type: "GET",
            dataType: "json",
            dataSrc: "",
        },

        "columnDefs": [{
            sortable: false,
            "class": "index",
            targets: 0
        }],
        order: [[1, 'asc']],
        fixedColumns: true,

        "columns": [
            { "data": null },
            { "data": "Id" },
            { "data": "PLATNumber" },
            { "data": "RequestDate" },
            { "data": "ParkingName" },
            { "data": "ParkingAddress" },
            { "data": "TotalPrice" },
            { "data": "ReimbursementStatus" },
            { "data": "RejectReason" },
            {
                "sortable": false,
                "data": "Id",
                "render": function (data, type, row) {
                    console.log(row);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-link btn-md btn-warning " data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + data + ')" ><i class="fa fa-lg fa-edit"></i></button>'
                        + '&nbsp;'
                        + '<button class="btn btn-link btn-md btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + data + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            },
        ]
    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

//function LoadDepart(element) {
//    debugger;
//    if (arrDepart.length === 0) {
//        $.ajax({
//            type: "Get",
//            url: "/departments/LoadDepart",
//            success: function (data) {
//                arrDepart = data;
//                renderDepart(element);
//            }
//        });
//    }
//    else {
//        renderDepart(element);
//    }
//}

//function renderDepart(element) {
//    debugger;
//    var $option = $(element);
//    $option.empty();
//    $option.append($('<option/>').val('0').text('Select Department').hide());
//    $.each(arrDepart, function (i, val) {
//        $option.append($('<option/>').val(val.Id).text(val.Name))
//    });
//}