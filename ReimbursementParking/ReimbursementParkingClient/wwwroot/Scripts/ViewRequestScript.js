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

function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
        if (result.value) {
            debugger;
            $.ajax({
                url: "/ViewRequest/Delete",
                data: { id: id }
            }).then((result) => {
                debugger;
                if (result.StatusCode == 200) {
                    debugger;
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Delete Successfully',
                        showConfirmButton: false,
                        timer: 1500,
                    });
                    table.ajax.reload(null, false);
                } else {
                    Swal.fire('Error', 'Failed to Delete', 'error');
                    ClearScreen();
                }
            })
        };
    });
}