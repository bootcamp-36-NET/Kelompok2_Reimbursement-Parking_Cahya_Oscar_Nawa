$('.select2').select2()

$(document).ready(function () {
    bsCustomFileInput.init();
    LoadInitialCreateData();
});

function LoadInitialCreateData() {
    $.ajax({
        url: "/RequestReimbursementParking/LoadInitialCreateData",
        data: "",
        cache: false,
        type: "GET",
        dataType: "JSON"
    }).then((result) => {
        var currPeriode = moment().format("MMMM YYYY");
        $('#EmployeeId').val(result.EmployeeId);
        $('#Name').val(result.Name);
        $('#Periode').val(currPeriode);
    });
}

function CreateNewRequest() {
    var check = validate();
    if (check == false) {
        return false;
    }
    var a = $('#ReimbursementFile')[0].files[0];
    let formData = new FormData();
    formData.append('EmployeeId', $('#EmployeeId').val());
    formData.append('Name', $('#Name').val());
    formData.append('PLATNumber', $('#PLATNumber').val());
    formData.append('VehicleOwner', $('#VehicleOwner').val());
    formData.append('VehicleType', $('#VehicleType').val());
    formData.append('TotalPrice', $('#TotalPrice').val());
    formData.append('ParkingAddress', $('#ParkingAddress').val());
    formData.append('ParkingName', $('#ParkingName').val());
    formData.append('PaymentType', $('#PaymentType').val());
    formData.append('ReimbursementFile', $('#ReimbursementFile')[0].files[0]);

    $.ajax({
        url: "/RequestReimbursementParking/CreateReimbursement",
        data: formData,
        type: 'post',
        contentType: false,
        processData: false,
    }).then((result) => {
        if (result.Item1.StatusCode == 200) {
            ClearForm();
            Swal.fire('scuccess', 'success', 'success');
        } else {
            Swal.fire('Error', 'Error', 'Error');
        }
    });
}

function validate() {
    var isValid = true;
    if ($('#PLATNumber').val().trim() == "") {
        $('#PLATNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PLATNumber').css('border-color', 'lightgrey');
    }
    if ($('#VehicleOwner').val().trim() == "") {
        $('#VehicleOwner').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#VehicleOwner').css('border-color', 'lightgrey');
    }
    if ($('#VehicleType').val().trim() == "") {
        $('#VehicleType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#VehicleType').css('border-color', 'lightgrey');
    }
    if ($('#TotalPrice').val().trim() == "") {
        $('#TotalPrice').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TotalPrice').css('border-color', 'lightgrey');
    }
    if ($('#ParkingAddress').val().trim() == "") {
        $('#ParkingAddress').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ParkingAddress').css('border-color', 'lightgrey');
    }
    if ($('#ParkingName').val().trim() == "") {
        $('#ParkingName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ParkingName').css('border-color', 'lightgrey');
    }
    if ($('#PaymentType').val().trim() == "") {
        $('#PaymentType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PaymentType').css('border-color', 'lightgrey');
    }
    if ($('#PaymentType').val().trim() == "") {
        $('#PaymentType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PaymentType').css('border-color', 'lightgrey');
    }
    return isValid;
}

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
            { "data": "id" },
            { "data": "platNumber" },
            { "data": "requestDate" },
            { "data": "parkingName" },
            { "data": "parkingAddress" },
            { "data": "totalPrice" },
            { "data": "reimbursementStatus" },
            { "data": "rejectReason" },
            {
                "sortable": false,
                "data": "id",
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

function ClearForm() {
    $('#PLATNumber').val('');
    $('#VehicleOwner').val('');
    $('#VehicleType').val('');
    $('#TotalPrice').val('');
    $('#ParkingAddress').val('');
    $('#ParkingName').val('');
    $('#PaymentType').val('');
    $('#ReimbursementFile').val('');
}

