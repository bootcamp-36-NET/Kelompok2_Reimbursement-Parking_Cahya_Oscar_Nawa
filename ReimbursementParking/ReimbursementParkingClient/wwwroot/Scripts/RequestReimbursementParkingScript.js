$('.select2').select2()
var periodeDropDown = $('#PeriodeDropDown');
var maxFileSize = 1048576;

$(document).ready(function () {
    bsCustomFileInput.init();
    LoadInitialCreateData();
    LoadPeriodeDropDown();
});

function LoadPeriodeDropDown() {
    periodeDropDown.empty();
    $.ajax({
        url: "/RequestReimbursementParking/LoadPerideDrowDown",
        data: "",
        cache: false,
        type: "GET",
        dataType: "JSON"
    }).then((results) => {
        if (results != null) {
            $.each(results, function (index, result) {
                if (index == 0) {
                    periodeDropDown.append("<option selected='selected'>" + result + "</option>");
                } else {
                    periodeDropDown.append("<option>" + result + "</option>");
                }
            });
        };
    });
}

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
    Swal.showLoading()
    var check = validate();
    if (check == false) {
        Swal.fire('Error', 'Invalid Data Input !', 'error');
        return false;
    }
    let formData = new FormData();
    formData.append('PLATNumber', $('#PLATNumber1').val() + ' ' + $('#PLATNumber2').val() + ' ' + $('#PLATNumber3').val());
    formData.append('Periode', $('#PeriodeDropDown').val());
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
            Swal.fire({
                title: 'Success',
                text: "Request Successfully created !",
                icon: 'success',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            }).then((result) => {
                window.location.href = "/ViewRequest";
            });
        } else {
            Swal.fire('Error', result.Item2, 'error');
        }
    });
}

function validate() {
    var isValid = true;
    if ($('#PLATNumber1').val().trim() == "") {
        $('#PLATNumber1').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PLATNumber1').css('border-color', 'lightgrey');
    }
    if ($('#PLATNumber2').val().trim() == "") {
        $('#PLATNumber2').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PLATNumber2').css('border-color', 'lightgrey');
    }
    if ($('#PLATNumber3').val().trim() == "") {
        $('#PLATNumber3').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PLATNumber3').css('border-color', 'lightgrey');
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

    if ($('#ReimbursementFile').val() == '') {
        Swal.fire('Error', 'File must be Choosen !', 'Error');
        isValid = false;
    }
    else {
        if ($('#ReimbursementFile')[0].files[0].size > maxFileSize) {
            Swal.fire('Error', 'File size is more than 1MB !', 'Error');
            isValid = false;
        } else if ($('#ReimbursementFile')[0].files[0].type != "application/pdf") {
            Swal.fire('Error', 'File content must be PDF', 'Error');
            isValid = false;
        }
        else {
            $('#ReimbursementFile').css('border-color', 'lightgrey');
        }
    }
    return isValid;
}

function ClearForm() {
    $('#PLATNumber1').val('');
    $('#PLATNumber2').val('');
    $('#PLATNumber3').val('');
    $('#VehicleOwner').val('');
    $('#TotalPrice').val('');
    $('#ParkingAddress').val('');
    $('#ParkingName').val('');
    $('#ReimbursementFile').value = '';
}

