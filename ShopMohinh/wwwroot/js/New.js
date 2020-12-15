var a = true;

function dropdown(i) {

    if (a) {
        document.getElementById("collapsesThongke").style.display = "block";
        a = false;
    } else {
        document.getElementById("collapsesThongke").style.display = "none";
        a = true;
    }

}



