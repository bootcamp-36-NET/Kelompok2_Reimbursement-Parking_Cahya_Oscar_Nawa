var table = null;
var approvedTable = null;
var rejectedTable = null;


$(document).ready(function () {
    LoadInitialCreateData();
    LoadApprovedByHRD();
    LoadRejectedByHRD();

   $.fn.dataTable.ext.search.push(
        function (settings, data, dataIndex) {
            var min = $('#min').datepicker("getDate");
            var max = $('#max').datepicker("getDate");
            var startDate = new Date(data[10]);
            if (min == null && max == null) { return true; }
            if (min == null && startDate <= max) { return true; }
            if (max == null && startDate >= min) { return true; }
            if (startDate <= max && startDate >= min) { return true; }
            return false;
        }
    );

    $("#min").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });
    $("#max").datepicker({ onSelect: function () { table.draw(); }, changeMonth: true, changeYear: true });

    // Event listener to the two range filtering inputs to redraw on input
    $('#min, #max').change(function () {
        table.draw();
    });
});

function LoadInitialCreateData() {
    table = $('#dataTable').DataTable({
        sScrollX: "100%",
        bScrollCollapse: true,
        sScrollY: "500px",
        bPaginate: true,
        fnRowCallback: function (nRow, aData, iDisplayIndex) {
            $('td', nRow).attr('nowrap', 'nowrap');
            return nRow;
        },
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
                title: "Employee ID",
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
                data: "RequestDate",
                render: function (data, type, row) {
                    var currPeriode = moment().format("MMMM YYYY");
                    return currPeriode;
                },
                sortable: false,
                oderable: false
            },
            {
                title: "Request Date",
                data: "RequestDate",
                render: function (data, type, row) {
                    var currPeriode = moment().format("MM/DD/YYYY");
                    return currPeriode;
                },
                sortable: false,
                oderable: false
            },
            {
                title: "File Data",
                data: "Id",
                render: function (data, type, row, meta) {
                    return '<Button class="btn btn-secondary" onclick="return DownloadFolder(' + row.Id + ')"><i class="fa fa-lg fa-file-download"></i></button>';
                },
                "sortable": false,
                "oderable": false
            },
            {
                title: "Action",
                data: "Id",
                render: function (data, type, row, meta) {
                    return '<Button class="btn btn-outline-success" data-placement="left"  data-toggle="Reject" onclick="return Approve(' + meta.row + ')"><i class="fa fa-lg fa-check"></i></button>'
                        + "&nbsp;"
                        + '<button onclick="ShowReject(' + meta.row + ')" class="btn btn-outline-danger" data-placement="right" data-toggle="Reject title = "Reject"><i class="fa fa-lg fa-window-close"></i></button>';
                },
                "sortable": false,
                "oderable": false
            }
        ],
        success: function (res) {
            console.log(res);
        }
    });

}

function LoadApprovedByHRD() {
    debugger;
    approvedTable = $('#dataApprovedTable').DataTable({
        ajax: {
            url: "/HRDApproval/GetApprovedByHRD",
            dataSrc: "",
            cache: false,
            type: "GET",
            dataType: "JSON"
        },
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
            { title: "Vehicle Type", data: "VehicleType" },
            { title: "Payment Type", data: "PaymentType" },
            { title: "Total Price", data: "TotalPrice" },
            { title: "Vehicle Owner", data: "VehicleOwner" },
            { title: "Parking Name", data: "ParkingName" },
            { title: "Parking Address", data: "ParkingAddress" },
            //{ title: "Content", data: "Content" },                            
        ]
    });
}

function LoadRejectedByHRD() {
    debugger;
    rejectedTable = $('#dataRejectedTable').DataTable({
        ajax:
        {
            url: "/HRDApproval/GetRejectedByHRD",
            dataSrc: "",
            cache: false,
            type: "GET",
            dataType: "JSON",
        },
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
            { title: "Vehicle Type", data: "VehicleType" },
            { title: "Payment Type", data: "PaymentType" },
            { title: "Total Price", data: "TotalPrice" },
            { title: "Vehicle Owner", data: "VehicleOwner" },
            { title: "Parking Name", data: "ParkingName" },
            { title: "Parking Address", data: "ParkingAddress" },
            { title: "Reason", data: "RejectReason" },
            //{ title: "Content", data: "Content" },                            
        ]
    });
}

function ShowReject(idx) {
    $('#Id').val(table.row(idx).data().Id);
    $('#EmployeeId').val(table.row(idx).data().EmployeeId);
    $('#Reason').val('');
    $('#rejectModal').modal('show');
}

function Approve(idx) {
    var approveVM = {
        Id: table.row(idx).data().Id,
        EmployeeId: table.row(idx).data().EmployeeId
    };
    $.ajax({
        url: "/HRDApproval/ApproveRequest",
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
function Reject() {
    var rejectVM = {
        Id: $('#Id').val(),
        EmployeeId: $('#EmployeeId').val(),
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
        table.ajax.reload(null, false);
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
    var fileName = reportName + ".pdf";
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

