//chech form
function checkField() {
    let isValid = true;

    //provera da li su sva input polja popunjena
    let input = document.getElementsByClassName('input-field');
    for (let i = 0; i < input.length; i++) {
        if (input[i].value == "" || input[i].value == null) {
            isValid = false;
            input[i].placeholder = "Ovo polje je obavezno";
        }
    }

    let price = document.getElementById("Price").value;
    if (!price.match(/^([1-9]{1}[0-9]{0,}(\.[0-9]{0,2})?|0(\.[1-9][0-9]?)|0(\.0[1-9]))$/)) {
        document.getElementById('lblPrice').innerHTML = "Cena mora biti veća od nule";
        isValid = false;
    }
    else {
        document.getElementById('lblPrice').innerHTML = "";
    }
    
    let amount = document.getElementById("Amount").value;
    if (!amount.match(/^[1-9][0-9]*$/)) {
        document.getElementById('lblAmount').innerHTML = "Količina mora biti veća od nule.";
        isValid = false;
    }
    else {
        document.getElementById('lblAmount').innerHTML = "";
    }

    //ako je forma ispravno popunjena
    if (isValid) {
        document.getElementById("btn-field-check").setAttribute("type", "submit");
    }
}