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
            {
                "data": "RequestDate",
                'render': function (jsonDate) {
                    var date = new Date(jsonDate);
                    return moment(date).format('DD MMMM YYYY');
                }
            },
            { "data": "ReimbursementStatus" },
            {
                "sortable": false,
                "data": "Id",
                "render": function (data, type, row, meta) {
                    console.log(row);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-link btn-md" data-placement="left" data-toggle="tooltip" data-animation="false" title="Detail" onclick="return GetById(' + meta.row + ')" ><i class="fa fa-lg fa-info"></i></button>'
                }
            },
            {
                "sortable": false,
                "data": "Id",
                "render": function (data, type, row, meta) {
                    if (row.ReimbursementStatus != "NewRequest") {
                        $('[data-toggle="tooltip"]').tooltip();
                        return '<button class="btn btn-outline-danger" data-placement="left" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + meta.row + ')" disabled><i class="fa fa-lg fa-trash"></i></button>'
                    }
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-danger" data-placement="left" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + meta.row + ')" ><i class="fa fa-lg fa-trash"></i></button>'
                }
            },
        ],

        initComplete: function () {
            this.api().columns(7).every(function () {
                var column = this;
                var select = $('<select><option value="">Reimbursement Status</option></select>')
                    .appendTo($(column.header()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        }
    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});


function Delete(idx) {
    var Id = table.row(idx).data().Id;
    debugger;
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
                data: { id: Id }
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
                }
            })
        };
    });
}

function GetById(idx) {
    var Id = table.row(idx).data().Id;
    debugger;
    $.ajax({
        url: "/ViewRequest/LoadRequestReq",
        type: "GET",
        dataType: "json",
        data: { id: Id }
    }).then((result) => {
        debugger;
        $('#ParkingName').val(result.ParkingName);
        $('#ParkingAddress').val(result.ParkingAddress);
        $('#TotalPrice').val(result.TotalPrice);
        $('#VeicleType').val(result.VeicleType);
        $('#RejectReason').val(result.RejectReason);
        $('#myModal').modal('show');
    })
}