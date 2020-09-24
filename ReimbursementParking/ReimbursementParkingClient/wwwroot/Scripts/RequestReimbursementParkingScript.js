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
    formData.append('ReimbursementFile', $('#ReimbursementFile').val(), $('#ReimbursementFile').val().Name);     

$.ajax({
    url: "/RequestReimbursementParking/CreateReimbursement",
    data: formData,
    headers: { "Content-Type": undefined },
    cache: false,
    type: "GET",
    dataType: "JSON"
}).then((result) => {
    if (result.Item1.StatusCode == 200) {

    } else {

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