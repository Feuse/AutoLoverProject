//$("select").change(function () {
//    console.log("test");
//    $("#panel").toggle("slow", "linear");
//});
var time;
var service;
var likesInput;
var username;
var password;

function test() {
    console.log("test");
}
function flipService() {
    //$("likes").css("display", "normal");
    $("#likes").fadeIn();
};

function validateUser() {
    $("#error").hide();
    $('.spinner-border').show();
    $("#pleaseWait").text("Validating, please do not refresh the page!").show();
    $.ajax({
        type: "POST",
        url: '/Actions/ValidateUser',
        data: $("#serviceLogIn").serialize(),
        dataType: "text",
        
        success: function () {
            $('.loader').hide();
            $("#pleaseWait").hide();
            $('#serviceLogIn').fadeOut();
            $('.checkOut').fadeIn();
            $("#StartLiking").fadeIn();
        },
        error: function () {
            $("#error").show();
            $("#error").text("Wrong username / password, please try again!");
            $('.spinner-border').hide();
            $("#pleaseWait").hide();
           
            
            
        }
    });
}
function schedule() {
    $.ajax({
        type: "POST",
        url: '/Actions/Schedule',
        data: $("#schedulerForm").serialize(),
        dataType: "text",
    });
}
function msg() {
    console.log(msg);
}

function submitForm() {

    $("#checkbox").fadeOut("slow", "linear")
    $("#likes").fadeOut("slow", "linear");
    $("#date").fadeOut("slow", "linear");
    $("#service").fadeOut("slow", "linear")
    $("#serviceLogIn").fadeIn();
    console.log("here");
    likes = document.getElementById('likesInput');
    service = document.getElementById('service');
    time = document.getElementById('datetimepicker1');

};

$(document).ready(function () {
    $('input[type="checkbox"]').click(function () {
        if ($(this).prop("checked") == true) {
            $("#date").slideUp("slow", "linear").fadeOut("slow", "linear");
        }
        else if ($(this).prop("checked") == false) {
            $("#date").slideDown("slow", "linear").fadeIn("slow", "linear");

        }
    });
});

//$(function () {
//    $('#datetimepicker1').datetimepicker();
//});
$('.likeInput').blur(function () {
    if (!$.trim(this.value).length) { // zero-length string AFTER a trim
        $(this).parents('p').addClass('warning');
    }
});
function submitCallBack() {
    console.log("bacll");
    $("#serviceLogIn").fadeIn();
}

function flipLikes() {

    $("#checkbox").fadeIn();
};

function flipDate() {
    var ele = document.getElementById("customCheck1").checked;
    if (ele) {
        $("#date").slideDown("slow", "linear").fadeIn("slow", "linear");
    } else {
        $("#date").slideUp("slow", "linear").fadeOut("slow", "linear");
    }
};

var x, i, j, selElmnt, a, b, c;
/* Look for any elements with the class "custom-select": */
x = document.getElementsByClassName("custom-select");
for (i = 0; i < x.length; i++) {
    selElmnt = x[i].getElementsByTagName("select")[0];
    /* For each element, create a new DIV that will act as the selected item: */
    a = document.createElement("DIV");
    a.setAttribute("class", "select-selected");
    a.innerHTML = selElmnt.options[selElmnt.selectedIndex].innerHTML;
    x[i].appendChild(a);
    /* For each element, create a new DIV that will contain the option list: */
    b = document.createElement("DIV");
    b.setAttribute("class", "select-items select-hide");
    for (j = 1; j < selElmnt.length; j++) {
        /* For each option in the original select element,
        create a new DIV that will act as an option item: */
        c = document.createElement("DIV");
        c.innerHTML = selElmnt.options[j].innerHTML;
        c.addEventListener("click", function (e) {
            /* When an item is clicked, update the original select box,
            and the selected item: */
            var y, i, k, s, h;
            s = this.parentNode.parentNode.getElementsByTagName("select")[0];
            h = this.parentNode.previousSibling;
            for (i = 0; i < s.length; i++) {
                if (s.options[i].innerHTML == this.innerHTML) {
                    s.selectedIndex = i;
                    h.innerHTML = this.innerHTML;
                    y = this.parentNode.getElementsByClassName("same-as-selected");
                    for (k = 0; k < y.length; k++) {
                        y[k].removeAttribute("class");
                    }
                    this.setAttribute("class", "same-as-selected");
                    break;
                }
            }
            h.click();
        });
        b.appendChild(c);
    }
    x[i].appendChild(b);
    a.addEventListener("click", function (e) {
        /* When the select box is clicked, close any other select boxes,
        and open/close the current select box: */
        e.stopPropagation();
        closeAllSelect(this);
        this.nextSibling.classList.toggle("select-hide");
        this.classList.toggle("select-arrow-active");
    });
}

function closeAllSelect(elmnt) {
    /* A function that will close all select boxes in the document,
    except the current select box: */
    var x, y, i, arrNo = [];
    x = document.getElementsByClassName("select-items");
    y = document.getElementsByClassName("select-selected");
    for (i = 0; i < y.length; i++) {
        if (elmnt == y[i]) {
            arrNo.push(i)
        } else {
            y[i].classList.remove("select-arrow-active");
        }
    }
    for (i = 0; i < x.length; i++) {
        if (arrNo.indexOf(i)) {
            x[i].classList.add("select-hide");
        }
    }
}

/* If the user clicks anywhere outside the select box,
then close all select boxes: */
document.addEventListener("click", closeAllSelect);