$(document).ready(function () {
    $("#authid").click(function (e) {
        if ($("#Email").val() != '' && $("#Paswword").val() != '') {
            if (validateEmail($("#Email").val())) {
                $.ajax({
                    type: 'POST',
                    url: "http://localhost:58465/Auth/api/authenticate",
                    data: JSON.stringify({
                        Login: $("#Email").val(),
                        Password: $("#Paswword").val()
                    }),
                    cors: true,
                    secure: true,
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    dataType: 'json',
                    success: function (result) {
                        $('#resultarea').val(result);
                    },
                    error: function (result) {
                        $('#resultarea').val("l''utilisateur saisie n''est pas reconnu");
                    }
                });
            } else {
                $('#resultarea').val('Veuillez saisir une adresse email correct');
            }
        }else {
            $('#resultarea').val('Veuillez saisir  une adresse email et/ou un mot de passe');
        }
        });
        $("#confid").click(function (e) {
            e.preventDefault();
            var date = new Date();
            var formatteddate = getFormattedDate(date);
            if ($("#Email").val() != '' && validateEmail($("#Email").val())) {
                $.ajax({
                    type: "GET",
                    url: "http://localhost:58465/Auth/api/confidentials?email=" + $("#Email").val(),
                    cors: true,
                    secure: true,
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                        'Accept': 'application/json',
                        'Content-Type': 'application/json',
                        'Authorization': 'VP AKIAIOSFODNN7EXAMPLE:GET_application/json_' + formatteddate
                    },
                    success: function (result) {
                        $('#resultarea').val(result);
                    },
                    error: function (result) {
                        $('#resultarea').val("l''utilisateur saisie n''est pas reconnu");
                    }
                });
            } else {
                $('#resultarea').val('Veuillez saisir une adresse email correct');
            }
        });
  });
function getFormattedDate(date) {

    var year = date.getFullYear();

    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;

    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;

    return day + '' + month + '' + year;
}

function validateEmail(sEmail) {
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    if (filter.test(sEmail)) {
        return true;
    }else {
        return false;
    }
}