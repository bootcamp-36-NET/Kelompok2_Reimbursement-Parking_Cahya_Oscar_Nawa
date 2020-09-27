var table = null;
var zip = new JSZip();

$(document).ready(function () {
    LoadInitialCreateData();
});

function LoadInitialCreateData() {
    table = $('#dataTable').DataTable({
        ajax: {
            url: "/HRDApproval/GetAllRequestHRD",
            dataSrc: "",
            cache: false,
            type: "GET",
            dataType: "JSON"
        },
        columns: [
            {
                title: "No",
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                },
                sortable: false,
                oderable: false

            },
            {
                title: "Employee Id",
                data: "EmployeeId"
            },
            {
                title: "PLAT Number",
                data: "PLATNumber"
            },
            {
                title: "Total Price",
                data: "TotalPrice"
            },
            {
                title: "Vehicle Owner Name",
                data: "VehicleOwner"
            },
            {
                title: "Vehicle Type",
                data: "VehicleType"
            },
            {
                title: "Parking Name",
                data: "ParkingName"
            },
            {
                title: "Parking Address",
                data: "ParkingAddress",
                AutoWidth: false
            },
            {
                title: "Payment Type",
                data: "PaymentType"
            },
            {
                title: "Periode",
                data: null,
                render: function (data, type, row) {
                    var currPeriode = moment().format("MMMM YYYY");
                    return currPeriode;
                },
                sortable: false,
                oderable: false
            },
            {
                title: "File Data",
                data: "Id",
                render: function (data, type, row, meta) {
                    return '<Button class="btn btn-secondary" onclick="return DownloadFolder(' + row.Id + ')">Download File</button>';
                },
                "sortable": false,
                "oderable": false
            },
            {
                title: "Action",
                data: "Id",
                render: function (data, type, row, meta) {
                    return '<Button class="btn btn-success" onclick="return Approve(' + data + ')">Approve</button>'
                        + '&nbsp;'
                        + '<button onclick="ShowReject(' + data + ')" class="btn btn-outline-danger" data - toggle="tooltip" data - placement="top"data - animation="false" title = "Reject">Reject</button>';
                },
                "sortable": false,
                "oderable": false
            }
        ],
    });

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
        dataType: "JSON",
    }).then((result) => {
        if (result.Item1.StatusCode == 200) {
            Swal.fire('Success', result.Item2, 'success');

        } else {
            Swal.fire('Error', result.Item2, 'error');
        }
        table.ajax.reload(null, false);
    });
}
function Reject() {
    var rejectVM = {
        RequestId: $('#Id').val(),
        RejectReason: $('#Reason').val()
    }
    $.ajax({
        url: "/HRDApproval/RejectRequest",
        data: rejectVM,
        type: "POST",
        dataType: "JSON",
    }).then((result) => {
        if (result.Item1.StatusCode == 200) {
            Swal.fire('Success', result.Item2, 'success');
            table.ajax.reload(null, false);
            $('#rejectModal').modal('hide');
        } else {
            Swal.fire('Error', result.Item2, 'error');
        }


    });
}

function DownloadFolder(Id) {
    $.ajax({
        url: "/HRDApproval/DownloadFolder/" + Id,
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

