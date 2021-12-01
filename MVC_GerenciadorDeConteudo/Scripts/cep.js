
jQuery(function ($){
    $("input[name='cep']").change(function () {
        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;
        $.get("viacep.com.br/ws/cep/json/", { code: cep_code }, function (result) {
            if (result.status != 200){
                alert(result.message || "Ops, houve um erro");
                return;
            }
            $("input[name='cep']").val(result.code);
            $("input[name='estado']").val(result.state);
            $("input[name='cidade']").val(result.city);
            $("input[name='bairro']").val(result.district);
            $("input[name='endereco']").val(result.address);
            
        });
    });
});