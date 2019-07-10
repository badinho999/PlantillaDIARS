
function logIn() {
    let username = $("#logusrname").val();
    let passw = $("#logpass").val();

    let validar = validarLogin(username,passw);

    if (validar) {
        $.ajax({
            url: "/Login/VerificarAcceso",
            type: "GET",
            data: { username: username, key: passw },
            dataType: "json",
            success: (result) => {

                if (result!=null) {
                    window.location.href = result.Url;

                   
                }
                else {
                    $("#logusrnameVal").attr("style", "display: block");
                    $("#logusrnameVal").attr("style", "color: red");
                    $("#logusrnameVal").text("Usuario o contraseña incorrectos");
                    $("#logusrname").attr("style", "border-color: red");
                }

            },

            error: (errormessage) => {

            }

        });
    }
    $("#logusrnameVal").attr("style", "display: none");
    $("#logusrnameVal").text("Complete este campo");
    $("#logusrname").attr("style", "border-color: blue");
    
};

function validarLogin(username, passw) {
    let validar = false;

    if (username == '') {
        $("#logusrnameVal").attr("style", "display: block");
        $("#logusrnameVal").attr("style", "color: red");
        $("#logusrname").attr("style", "border-color: red");

        $("#logpass").attr("style", "border-color: blue");
s
        $("#logpassVal").attr("style", "display: none");
    }
    else if (passw == '') {
        $("#logpassVal").attr("style", "display: block");
        $("#logpassVal").attr("style", "color: red");
        $("#logpass").attr("style", "border-color: red");

        $("#logusrname").attr("style", "border-color: blue");

        $("#logusrnameVal").attr("style", "display: none");
    }
    else {
        validar = true;
    }
    return validar;
}