var time;
var likesInput;
var username;
var password;
var service;

function test() {
    console.log("test");
}
function flipService() {
    $("#likes").fadeIn();
};


$(document).ready(function () {
    $.ajax({
        url: '/Actions/ClearSession',
        method: 'POST',
        dataType: 'text',
        success: function () {

        },
        error: function () {

        }
    });


    $.ajax({
        url: '/Actions/GetUserServices',
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                document.getElementById("serviceName").value = data[i];
            };
        },
        error: function (data) {
            var d = data;
            var imashelha = JSON.stringify(data);
            alert(imashelha);
        }
    });
});

$(document).ready(function () {
    $("#userServicesDropDown").on("change", fade);
});
function fade() {
    $("#likesInput").val("");
    if ($("#myonoffswitch").is(":not(:checked)")) {
        $("#date").fadeOut("slow", "linear");
        slideDate();
    }
    $("#myonoffswitch").prop('checked', true);

}

$(document).ready(function () {

    $('#autocomplete2').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Actions/AutoComplete',
                method: 'POST',
                data: $("#autoCompleteForm").serialize(),
                dataType: 'json',
                success: function (data) {
                    response(data)
                },
                error: function (error) {
                    alert(error);
                }
            })
        }
    })
});


$(document).ready(function () {

    $('.butt').mouseenter(function () {
        $(this).fadeTo('fast', 1);
    });
    $('.butt').mouseleave(function () {
        $(this).fadeTo('fast', 0.7);
    });
    $('.addPicture').mouseenter(function () {
        $(this).fadeTo('fast', 1);
    });
    $('.addPicture').mouseleave(function () {
        $(this).fadeTo('fast', 0.7);
    });
});

function upload() {



    var formdata = new FormData($('#formt')[0]);

    if ($("#file").val() !== "") {
        $.ajax({
            type: "POST",
            url: '/Actions/UploadImage',
            data: formdata,
            processData: false,
            contentType: false,
            success: function (data) {
            },
            error: function (e) {
                console.log(e.responseText);
            }
        });
    }
}

$(document).ready(function () {
    $(".singleElement").click(function () {
        var atr = $(this).attr("data-id");
        var elem = this.innerHTML;
        if (elem.includes("Change")) {
            $.ajax({
                type: "POST",
                url: '/Actions/ChangePicture',
                data: atr,
                dataType: "text",
                success: function (data) {
                    //switch pictures
                    //or remove current, and replance with new.
                },
                error: function () {

                }
            });
        }
        if (elem.includes("Make")) {
            $.ajax({
                type: "POST",
                url: '/Actions/MakeProfile',
                data: atr,
                dataType: "text",
                success: function (data) {
                    //set profile picture as current
                },
                error: function () {

                }
            });
        }
        if (elem.includes("Delete")) {
            $.ajax({
                type: "POST",
                url: '/Actions/DeletePicture',
                data: atr,
                dataType: "text",
                success: function (data) {
                    //remove picture by id
                },
                error: function () {

                }
            });
        }

    });
});


function getval(sel) {
    alert(sel.value);
    if (sel.value == "Badoo") {
        $(".badoo").css("display", "block").fadeOut("slow", "linear");
        $(".badoo").slideDown("slow", "linear").fadeIn("slow", "linear");
        $(".tinder").css("display", "none").fadeOut("slow", "linear");
        $(".grinder").css("display", "none").fadeOut("slow", "linear");
        $(".okCupid").css("display", "none").fadeOut("slow", "linear");
    } if (sel.value == "Tinder") {
        $(".tinder").slideDown("slow", "linear").fadeIn("slow", "linear");
        $(".badoo").fadeOut("slow", "linear").css("display", "none");
        $(".grinder").css("display", "none").fadeOut("slow", "linear");
        $(".okCupid").css("display", "none").fadeOut("slow", "linear");
    } if (sel.value == "Grinder") {
        $(".grinder").slideDown("slow", "linear").fadeIn("slow", "linear");
        $(".tinder").css("display", "none").fadeOut("slow", "linear");
        $(".badoo").css("display", "none").fadeOut("slow", "linear");
        $(".okCupid").css("display", "none").fadeOut("slow", "linear");
    } if (sel.value == "OkCupid") {
        $(".okCupid").slideDown("slow", "linear").fadeIn("slow", "linear");
        $(".tinder").css("display", "none").fadeOut("slow", "linear");
        $(".grinder").css("display", "none").fadeOut("slow", "linear");
        $(".badoo").css("display", "none").fadeOut("slow", "linear");
    }
}

var str = "eeseses";
function validateUser() {
    console.log(str);
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
            $.ajax({
                url: '/Actions/GetUserImages',
                method: 'GET',
                dataType: 'json',
                success: function (data) {
                    $.each(data, function (key, record) {
                        console.log("11")
                        $('.userPictures').append('<div class="singleImage" data-id=' + record.photoId + '><img class= "img" src=' + record.previewUrl + '/><button class="dropdowncust butt fas fa-ellipsis-v"><div class="dropdown-contentcust"><div class="singleElement"><p>Change picture</p></div><div class="singleElement"><p>Delete picture</p></div><div class="singleElement"><p>Make private</p></div></div></button></div>');
                    });
                    $('.userPictures').append('<div class="addPicture"><div class="pictureSquare"><div class="camIcon"><i class="fas fa-camera fa-3x "></i><div class="addAPicture"><form id="formt" enctype="multipart/form-data"><input onchange="upload()" id="file" asp-for="Photo" type="file"/><input id="service2" asp-for="Service"/><i>Add a picture</i></form></div></div></div></div>');

                    $(".singleImage").click(function () {
                        var atr = $(this).attr("data-id");
                        console.log(atr);
                    });



                },
                error: function (error) {
                    alert(error, error, error);
                }
            })
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
function changeDesc() {
    $.ajax({
        type: "POST",
        url: '/Actions/ChangeDescription',
        data: $("#ChangeDesc").serialize(),
        dataType: "text",
    });
}

function getCity() {
    $.ajax({
        type: "POST",
        url: '/Actions/GetCountry',
        data: $("#autocomplete2").serialize(),
        dataType: "text",
        success: function (data) {
            alert("woooh");
        },
        error: function (error) {
            alert(error);
        }
    });
}

$(document).ready(function () {
    $("#autocomplete").autocomplete({
        source: '/Users/ChangeDescription'

    })
});

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
function submitValidatedForm() {

    $("#checkbox").fadeOut("slow", "linear")
    $("#likes").fadeOut("slow", "linear");
    $("#date").fadeOut("slow", "linear");
    $("#service").fadeOut("slow", "linear")
    $(".checkOut").fadeIn();
    $("#StartLiking").fadeIn();

    console.log("here");
    likes = document.getElementById('likesInput');
    service = document.getElementById('service');
    time = document.getElementById('datetimepicker1');

};

$(document).ready(function () {
    $('#myonoffswitch').on("change", slideDate);
});

function slideDate() {

    if ($(this).prop("checked") == true) {
        $("#date").slideUp("slow", "linear").fadeOut("slow", "linear");
    }
    else if ($(this).prop("checked") == false) {
        $("#date").slideDown("slow", "linear").fadeIn("slow", "linear");
    }
};


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

