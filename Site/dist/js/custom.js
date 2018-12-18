$(function () {

  'use strict';
$('#preloader').fadeOut('slow',function(){$(this).hide();});


  // ------------------
  // - DELETE -
  // ------------------
  $('.delete').click(function () {
        var $this = $(this);
        var id=$(this).attr("data-id");
        $.get( "/Clientes/delete/"+id, { } )
          .done(function( data ) {

                    if(data.sucess==true){
                    location.reload(); 
}
                    
          });

  });



 $('.cep').change(function () {

$('#preloader').fadeOut('slow',function(){$(this).show();});

$.ajax({
                    type: "GET",
                    url: "http://198.24.161.132/fatec/api/correios/cep/" +$(this).val(),
                    dataType: "json",
                    success: function(data){  				
	
                        $("#Cidade").val(data.localidade);
                        $("#UF").val(data.uf);
                        $("#Logradouro").val(data.logradouro);
                        $("#Bairro").val(data.bairro);
                        $("#Temperatura").val(data.temperaturas[0].max);
                        $('#preloader').fadeOut('slow',function(){$(this).hide();});


                    },beforeSend: function(){			
                    $('#preloader').fadeOut('slow',function(){$(this).hide();});
                    },
                    complete: function(){					
                    $('#preloader').fadeOut('slow',function(){$(this).hide();});
                    },
                    error: function (xhr, status, error) {
                    $('#preloader').fadeOut('slow',function(){$(this).hide();});                        
                     
                    }
                });

  


  });


});
