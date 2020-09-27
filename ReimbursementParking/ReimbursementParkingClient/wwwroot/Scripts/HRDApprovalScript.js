var table = null;
var zip = new JSZip();

$(document).ready(function () {
    LoadInitialCreateData();
});

function LoadInitialCreateData() {
    table = $('#dataTable').DataTable({
        orderCellsTop: true,
        fixedHeader: true,
        ajax: {
            url: "/HRDApproval/GetAllRequestHRD",
            dataSrc: "",
            cache: false,
            type: "GET",
            dataType: "JSON"
        },
        columns: [
            { data: null },
            { data: "employeeId" },
            { data: "platNumber" },
            { data: "totalPrice" },
            { data: "vehicleOwner" },
            { data: "vehicleType" },
            { data: "parkingName" },
            {
                data: "parkingAddress",
                AutoWidth: false
            },
            { data: "paymentType" },
            {
                data: null,
                render: function (data, type, row) {
                    var currPeriode = moment().format("MMMM YYYY");
                    return currPeriode;
                },
                sortable: false,
                oderable: false
            },
            {
                data: "id",
                render: function (data, type, row, meta) {
                    return '<Button class="btn btn-secondary" onclick="return DownloadFolder(' + row.Id + ')">Download File</button>';
                },
                "sortable": false,
                "oderable": false
            },
            {
                data: "id",
                render: function (data, type, row, meta) {
                    return '<Button class="btn btn-success" onclick="return Approve(' + data + ')">Approve</button>'
                        + '&nbsp;'
                        + '<button onclick="ShowReject(' + data + ')" class="btn btn-outline-danger" data - toggle="tooltip" data - placement="top"data - animation="false" title = "Reject">Reject</button>';
                },
                "sortable": false,
                "oderable": false
            }
        ],
        "columnDefs": [{
            "searchable": false,
            "orderable": false,
            "targets": 0
        }],
        "order": [[1, 'asc']]
    });

    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
}

function ShowReject(id) {
    $('#Id').val(id);
    $('#Reason').val('');
    $('#rejectModal').modal('show');
}

function Approve(id) {
    $.ajax({
        url: "/HRDApproval/ApproveRequest/" + id,
        type: "POST",
        dataType: "JSON"
    }).then((result) => {
        if (result.Item1.StatusCode == 200) {
            Swal.fire('Success', result.Item2, 'success');
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', result.Item2, 'error');
        }

    });
}
function Reject() {
    var Id = $('#Id').val();
    var Reason = $('#Reason').val();
    $.ajax({
        url: "/HRDApproval/RejectRequest/" + Id,
        data: Reason,
        cache: false,
        type: "POST",
        dataType: "JSON"
    }).then((result) => {
            if (result.Item1.StatusCode == 200) {
                Swal.fire('Success', result.Item2, 'success');

            } else {
                Swal.fire('Error', result.Item2, 'error');
            }
            $('#rejectModal').modal('hide');

        });
}

function DownloadFolder() {
    var Id = $('#EmployeeID').val();
    $.ajax({
        url: "/HRDApproval/DownloadFolder/" + Id,
        data: { Id: Id },
        cache: false,
        type: "GET",
        dataType: "JSON",
        download: {
            mimetype: this.Response.Item2.ContentType,
            filename: this.Response.Item2.Name,
            data: this.Response.Item2.Content
        }
    }).then((result) => {
        if (result.Item1.StatusCode == 200) {

        } else {
            Swal.fire('Error', result.Item2, 'error');
        }
    });
}


