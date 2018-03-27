
$(document).ready(function () {

    var maxlengthNotas = 250;
    $('.notas').keypress(function (k) {
        if ($(this).val().length >= maxlengthNotas) {
            k.preventDefault();
        }

    });
    var maxlengthNums = 14;
    $('.nums').keypress(function (k) {
        if ($(this).val().length >= maxlengthNums) {
            k.preventDefault();
        }

    });
    var maxlengtNombreAtendio = 100;
    $('.nombreA').keypress(function (k) {
        if ($(this).val().length >= maxlengtNombreAtendio) {
            k.preventDefault();
        }

    });

    $('select').material_select();
    $('.modal').modal();  
    $('.id').hide();

    if ($('.numcE').val() != null && $('.numcE').val().length > 0) {
        $("#cp1").prop('checked', true);
        $('#cE').show();
    }
    else {
        $("#cp1").prop('checked', false);
        $('#cE').hide();
    }
  


    if ($('.numsE').val() != null && $('.numsE').val().length > 0) {
        $("#cs1").prop('checked', true)
        $('#sE').show();
    }
    else {
        $("#cs1").prop('checked', false);
        $('#sE').hide();
    }
   



    $(function (request, response) {
       

            $.ajax({
                url: '/Personas/GetUserData',
                dataType: "json",
                data: { userID: $('.nombre').val() },
                success: function (data) {
                    response($.map(data, function (item) {

                        $('.esconder').hide();
                        $('.id').show();
                        $('.id').focus();
                        $('.id').val(item.Nombre)
                        //return { label: item.Nombre, value: item.Id_Persona }
                    }));
                },
                //error: function (xhr, status, error) {
                //    alert("Error");
                //}
        });


        
    });
 
});


$('.nombre').autocomplete({
    source: function (request, response) {
        $.ajax({
            url: '/Personas/BuscarPersonas',
            dataType: "json",
            data: { search: $('.nombre').val() },
            success: function (data) {
                response($.map(data, function (item) {

    
                   
                    return { label: "nombre: " + item.Nombre+"   |"+"|"+"  Correo: "+ item.Correo, value:item.Id_Persona }
                }));         
            },
            error: function (xhr, status, error) {
                alert("Error");
            }
        });
    }
});


$(function () {
    $(function (request, response) {
        $('.nombre').focusout(function () {
            
            $.ajax({
                url: '/Personas/GetUserData',
                dataType: "json",
                data: { userID: $('.nombre').val() },
                success: function (data) {
                    response($.map(data, function (item) {

                        $('.esconder').hide();
                        
                        $('.id').show();
                        $('.id').focus();
                        $('.id').val(item.Nombre)
                        //return { label: item.Nombre, value: item.Id_Persona }
                    }));
                },
                //error: function (xhr, status, error) {
                //    alert("Error");
                //}
            });
        });
    });

});

$(function () {
    $(function (request, response) {
        $('.nombre').focusout(function () {

            $.ajax({
                url: '/Personas/GetUserNums',
                dataType: "json",
                data: { userID: $('.nombre').val() },
                success: function (data) {
                    response($.map(data, function (item) {


                        
                     


                        $('.nums').val(item.NumSerieSmart)
                        if ($('.nums').val() != null && $('.nums').val().length > 0) {
                            $("#cs1").prop('checked', true);
                            $('#s').show();
                            $('.nums').focus();
                        }
                        $('.numc').val(item.NumSerieCampeon)
                        if ($('.numc').val() != null && $('.numc').val().length > 0) {
                            $("#cp1").prop('checked', true);
                            $('#c').show();
                            $('.numc').focus();
                        }
                       
                        return 0;
                    }));
                },
                //error: function (xhr, status, error) {
                //    alert("Error");
                //}
            });
        });
    });

});



//script para la validacion de los numeros de serie campeon plus y smart
$(document).ready(function () {
    $('#s').hide();
    $('#c').hide();

    $("#cp").change(function () {
        if ($("#cp1").is(":checked"))  {
            $('#c').show();
            $('#cE').show();
        }
        else {
            $('#c').hide();
            $('#cE').hide();
        }
    })

    $("#cs").change(function () {
        if ($("#cs1").is(":checked")) {
            $('#s').show();
            $('#sE').show();
        }
        else {
            $('#s').hide();
            $('#sE').hide();
           
        }
    })
})

//validacion para poner solo numeros en los input de telefono
$('.number').keydown(function (e) {

    //borrar y enter
    if ($.inArray(e.keyCode, [9, 8, 13, 109]) !== -1 ||
        // Disponible: inicio, fin, izquierda, derecha
        (e.keyCode >= 37 && e.keyCode <= 40)) {
        return;
    }
    // Solo usar teclas numericas
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();//retornar
    }
    //aceptar maximo 10 numeros en los input de telefono
    var maxlength = 10;
    $('.number').keypress(function (k) {
        if ($(this).val().length >= maxlength) {
            k.preventDefault();
        }

    });
});






