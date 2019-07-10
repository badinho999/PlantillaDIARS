//Prevent modal close background
$('#maccount').modal({
    backdrop: 'static',
    keyboard: false,
    show: false
});

//Validar inputs
$("#email").blur(() => {

    let email = $("#email").val();

    $.ajax({
        url: "/Account/VerifyEmail",
        type: "GET",
        data: { email: email },
        success: (result) => {

            if (result != null) {
                $("#emailVal").attr("style", "display: block");
                $("#emailVal").attr("style", "color: red");
                $("#emailVal").text("Este email ya está en uso");
                $("#email").attr("style", "border-color: red");
            }
            else {
                $("#emailVal").attr("style", "display: none");
                $("#emailVal").text("Complete este campo");
                $("#email").attr("style", "border-color: blue");
            }

        },

        error: (errormessage) => {

        }

    });
    $("#emailVal").attr("style", "display: none");
    $("#emailVal").text("Complete este campo");
    $("#email").attr("style", "border-color: blue");
});

$("#username").blur(() => {
    let username = $("#username").val();

    $.ajax({
        url: "/Account/VirifyUsername",
        type: "GET",
        data: { NombreUsuario: username },
        success: (result) => {

            if (result != null) {
                $("#usrVal").attr("style", "display: block");
                $("#usrVal").attr("style", "color: red");
                $("#usrVal").text("Este nombre de usuario ya está en uso");
                $("#username").attr("style", "border-color: red");
            }
            else {
                $("#usrVal").attr("style", "display: none");
                $("#usrVal").text("Complete este campo");
                $("#username").attr("style", "border-color: blue");
            }

        },

        error: (errormessage) => {

        }

    });
    $("#usrVal").attr("style", "display: none");
    $("#usrVal").text("Complete este campo");
    $("#username").attr("style", "border-color: blue");
});

$("#dni").blur(() => {
    let dni = $("#dni").val();

    $.ajax({
        url: "/Cliente/VerifyDni",
        type: "GET",
        data: { Dni: dni },
        success: (result) => {

            if (result != null) {
                $("#dniVal").attr("style", "display: block");
                $("#dniVal").attr("style", "color: red");
                $("#dniVal").text("Este DNI ya está en uso");
                $("#dni").attr("style", "border-color: red");
            }
            else {
                $("#dniVal").attr("style", "display: none");
                $("#dniVal").text("Complete este campo");
                $("#dni").attr("style", "border-color: blue");
            }

        },

        error: (errormessage) => {

        }

    });
    $("#dniVal").attr("style", "display: none");
    $("#dniVal").text("Complete este campo");
    $("#dni").attr("style", "border-color: blue");
});
//

//Crea cliente
function signUp() {
    var sex = 0;

    if ($("input[name=rbS]").val() == "option1") {
        sex = 1;
    }

    var cliente = {
        Dni: $("#dni").val(),
        ApellidosCliente: $("#apellidos").val(),
        NombreCliente: $("#nombre").val(),
        FechaNacimiento: $("#fn").val(),
        Sexo: sex
    };

    let validar = validarCliente(cliente);

    if(validar) {

        $.ajax({
            url: "/Cliente/SignUp",
            data: JSON.stringify(cliente),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: (result) => {
                //Cambiar al modal para crear la cuenta
                $("#accountModal").append(`
                <input type="hidden" class="form-control" id="DNI" placeholder="Username"  value="${cliente.Dni}"/>
                 `);
                $("#signUp").modal('hide');
                $("#maccount").modal('show');
            },

            error: (errormessage) => {
                $(".alert_info").append(
                    `<div class="alert alert-dismissible alert-danger">
                <strong>Ups!</strong> Al parecer este DNI ya está en uso <a href="#" class="alert-link">No nos trates de engañar amiguito</a>.
                </div>`
                );
                setTimeout(() => {
                    $('.alert_info').remove();
                }, 2000);
            }
        });
    }
    
}

//Finalizar registro (crea cuenta)
function signUpEnd() {
    var cliente = {
        Dni: $("#DNI").val()
    };

    var passwordAccount =
    {
        PasswordString: $("#pass").val()
    };

    var account = {
        Email: $("#email").val(),
        NombreUsuario: $("#username").val(),
        Cliente: cliente,
        Telefono: $("#phone").val()
    }

    var accountViewModel = {
        Account: account,
        PasswordAccount: passwordAccount
    };

    
    let validar = validarCuenta(accountViewModel);

    if(validar) {
        $.ajax({
            url: "/Account/NewAccount",
            data: JSON.stringify(accountViewModel),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: (result) => {
                //Se crea la cuenta
                $("#DNI").remove();
                $("#maccount").modal('hide');

                $(".alert_info").append(
                    `<div class="alert alert-dismissible alert-success">
                <strong>Bienvenido ${account.NombreUsuario}!</strong> Se completó el registro <a href="#" class="alert-link">eres un capo</a>.
                </div>`
                );

                setTimeout(() => {
                    $('.alert_info').remove();
                }, 3000);
                
            },

            error: (errormessage) => {
                $(".alert_info").append(
                    `<div class="alert alert-dismissible alert-danger">
                <strong>Ups!</strong> Al parecer el nombre de usuario ya está ocupado<a href="#" class="alert-link">No nos trates de engañar amiguito</a>.
                </div>`
                );
                setTimeout(() => {
                    $('.alert_info').remove();
                }, 2000);
            }

        });
    }
}

function deleteClient() {
    var cliente = {
        Dni: $("#DNI").val()
    };

    $.ajax({
        url: "/Cliente/DeleteCliente",
        data: JSON.stringify(cliente),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: (result) => {
            //Se crea la cuenta
            $("#maccount").modal('hide');

            $(".alert_info").append(
                `<div class="alert alert-dismissible alert-success">
                <strong>Fue un gusto conocerte</strong> Se candeló el registro <a href="#" class="alert-link">eres un capo</a>.
                </div>`
            );

            setTimeout(() => {
                $('.alert_info').remove();
            }, 3000);

        },

        error: (errormessage) => {
            $(".alert_info").append(
                `<div class="alert alert-dismissible alert-danger">
                <strong>Ups!</strong> Al parecer el nombre de usuario ya está ocupado<a href="#" class="alert-link">No nos trates de engañar amiguito</a>.
                </div>`
            );
            setTimeout(() => {
                $('.alert_info').remove();
            }, 2000);
        }

    });
};

function validarCliente(cliente) {
    let validar = false;

    if (cliente.Dni == '') {
        $("#dniVal").attr("style", "display: block");
        $("#dniVal").attr("style", "color: red");
        $("#dni").attr("style", "border-color: red");

        $("#apellidos").attr("style", "border-color: blue");
        $("#nombre").attr("style", "border-color: blue");
        $("#fn").attr("style", "border-color: blue");



        $("#apeVal").attr("style", "display: none");
        $("#nameVal").attr("style", "display: none");
        $("#dateVal").attr("style", "display: none");
    }
    else if (cliente.ApellidosCliente == '') {
        $("#apeVal").attr("style", "display: block");
        $("#apeVal").attr("style", "color: red");
        $("#apellidos").attr("style", "border-color: red");

        $("#dni").attr("style", "border-color: blue");
        $("#nombre").attr("style", "border-color: blue");
        $("#fn").attr("style", "border-color: blue");

        $("#dniVal").attr("style", "display: none");
        $("#nameVal").attr("style", "display: none");
        $("#dateVal").attr("style", "display: none");
    }
    else if (cliente.NombreCliente == '') {
        $("#nameVal").attr("style", "display: block");
        $("#nameVal").attr("style", "color: red");
        $("#nombre").attr("style", "border-color: red");

        $("#dni").attr("style", "border-color: blue");
        $("#apellidos").attr("style", "border-color: blue");
        $("#fn").attr("style", "border-color: blue");

        $("#dniVal").attr("style", "display: none");
        $("#apeVal").attr("style", "display: none");
        $("#dateVal").attr("style", "display: none");
    }
    else if (cliente.FechaNacimiento == '') {
        $("#dateVal").attr("style", "display: block");
        $("#dateVal").attr("style", "color: red");
        $("#fn").attr("style", "border-color: red");

        $("#dni").attr("style", "border-color: blue");
        $("#apellidos").attr("style", "border-color: blue");
        $("#nombre").attr("style", "border-color: blue");

        $("#dniVal").attr("style", "display: none");
        $("#apeVal").attr("style", "display: none");
        $("#nameVal").attr("style", "display: none");
    }
    else if (cliente.Dni.length < 7) {
        $("#dniVal").attr("style", "display: block");
        $("#dniVal").attr("style", "color: red");
        $("#dni").attr("style", "border-color: red");

        $("#fn").attr("style", "border-color: blue");
        $("#apellidos").attr("style", "border-color: blue");
        $("#nombre").attr("style", "border-color: blue");

        $("#dateVal").attr("style", "display: none");
        $("#apeVal").attr("style", "display: none");
        $("#nameVal").attr("style", "display: none");
    }
    else {
        validar = true;
    }

    return validar;
}

function validarCuenta(accountViewModel) {
    let validar = false;

    let account = accountViewModel.Account;
    let passw = accountViewModel.PasswordAccount.PasswordString;

    if (account.NombreUsuario == '') {
        $("#usrVal").attr("style", "display: block");
        $("#usrVal").attr("style", "color: red");
        $("#username").attr("style", "border-color: red");

        $("#email").attr("style", "border-color: blue");
        $("#phone").attr("style", "border-color: blue");
        $("#pass").attr("style", "border-color: blue");

        $("#emailVal").attr("style", "display: none");
        $("#phoneVal").attr("style", "display: none");
        $("#passVal").attr("style", "display: none");
    }
    else if (account.Email == '') {
        $("#emailVal").attr("style", "display: block");
        $("#emailVal").attr("style", "color: red");
        $("#email").attr("style", "border-color: red");

        $("#username").attr("style", "border-color: blue");
        $("#phone").attr("style", "border-color: blue");
        $("#pass").attr("style", "border-color: blue");

        $("#usrVal").attr("style", "display: none");
        $("#phoneVal").attr("style", "display: none");
        $("#passVal").attr("style", "display: none");
    }
    else if (passw == '') {
        $("#passVal").attr("style", "display: block");
        $("#passVal").attr("style", "color: red");
        $("#pass").attr("style", "border-color: red");

        $("#username").attr("style", "border-color: blue");
        $("#phone").attr("style", "border-color: blue");
        $("#email").attr("style", "border-color: blue");

        $("#usrVal").attr("style", "display: none");
        $("#phoneVal").attr("style", "display: none");
        $("#emailVal").attr("style", "display: none");
    }

    else if (account.Telefono == '') {
        $("#phoneVal").attr("style", "display: block");
        $("#phoneVal").attr("style", "color: red");
        $("#phone").attr("style", "border-color: red");

        $("#username").attr("style", "border-color: blue");
        $("#email").attr("style", "border-color: blue");
        $("#pass").attr("style", "border-color: blue");

        $("#usrVal").attr("style", "display: none");
        $("#emailVal").attr("style", "display: none");
        $("#passVal").attr("style", "display: none");
    }
    else {
        validar = true;
    }
    return validar;
}