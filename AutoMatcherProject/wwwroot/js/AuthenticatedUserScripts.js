var time;
var likesInput;
var username;
var password;
var service;
var validated = false;
var gender = new Array();

function flipServiceAuth() {
    validateUserAuth(username, password, service);
    $("#StartLikingAuth").fadeIn();
};

function updateTextInput(val) {
    document.getElementById('textRangeInput').value = val;
}

function startAuth() {
    $.ajax({
        url: '/Actions/GetUserServices',
        method: 'GET',
        success: function (data) {
            $("#tet").append('<a>' + data + '</a>');
        },
        error: function (error) {
            alert(error);
        }
    })
}
$(document).ready(function () {
    $("#StartLikingAuth").on("change", fadeIn);
});
$(document).ready(function () {
    $("#userServicesDropDownAuth").on("change", fadeAuth);
});
function fadeAuth() {
    $("#likesInputAuth").val("");
    if ($("#myonoffswitchAuth").is(":not(:checked)")) {
        $("#dateAuth").fadeOut("slow", "linear");
        slideDate();
    }
    $("#myonoffswitchAuth").prop('checked', true);

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

$(document).ready(function () {
    // Listen to submit event on the <form> itself!
    $('#formt').submit(function (e) {

        e.preventDefault();
    });
});

function uploadAuth() {
    $('#file').click(function (e) {

        e.preventDefault();

    });
    var formdata = new FormData($('#formt')[0]);

    if ($("#file").val() !== "") {
        $.ajax({
            type: "POST",
            url: '/Actions/UploadImage',
            data: formdata,
            processData: false,
            contentType: false,
            success: function (data) {
                var d = data;
               
                $('.userPicturesAuth').append('<div class="singleImage"><img class= "img" src=" ' + data + ' "/><button class="dropdowncust butt fas fa-ellipsis-v"><div class="dropdown-contentcust"><div class="singleElement"><p>Change picture</p></div><div class="singleElement"><p>Delete picture</p></div><div class="singleElement"><p>Make private</p></div></div></button></div>');

            },
            error: function (e) {
                console.log(e.responseText);
            }
        });
    }
}
function deleteImage(data) {
    var s = $('#userServicesDropDownAuth :selected').text()
    var i = String(data)
    var input = {
        service: s,
        imgId: i
    };
    //input = JSON.stringify(input);
    $.ajax({
        type: "POST",
        url: '/Actions/RemoveImage',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(input),
        success: function (data) {
            $('.userPicturesAuth').empty();
            $('.userPicturesAuth').append('<div class="addPicture"><div class="pictureSquare"><div class="addAPicture"><button class="upload-images" onclick="uploadImages()"><i class="fas fa-camera"></i></button></div></div></div>');

            $.each(data.images, function (key, record) {
                $('.userPicturesAuth').append('<div class="singleImage" data-id=' + record.photoId + '><img class= "img" src=' + record.previewUrl + '/><button class="dropdowncust butt fas fa-ellipsis-v"><div class="dropdown-contentcust"><div class="singleElement"><p>Change picture</p></div><div class="singleElement"><p onclick="deleteImage(' + record.photoId + ')">Delete picture</p></div><div class="singleElement"><p>Make private</p></div></div></button></div>');
            });
        },
        error: function () {

        }
    });
}

//$(document).ready(function () {
//    $(".singleElement").click(function () {
//        var atr = $(this).attr("data-id");
//        var elem = this.innerHTML;
//        if (elem.includes("Change")) {
//            $.ajax({
//                type: "POST",
//                url: '/Actions/ChangePicture',
//                data: atr,
//                dataType: "text",
//                success: function (data) {
//                    //switch pictures
//                    //or remove current, and replance with new.
//                },
//                error: function () {

//                }
//            });
//        }
//        if (elem.includes("Make")) {
//            $.ajax({
//                type: "POST",
//                url: '/Actions/MakeProfile',
//                data: atr,
//                dataType: "text",
//                success: function (data) {
//                    //set profile picture as current
//                },
//                error: function () {

//                }
//            });
//        }
//        if (elem.includes("Delete")) {
//            $.ajax({
//                type: "POST",
//                url: '/Actions/DeletePicture',
//                data: atr,
//                dataType: "text",
//                success: function (data) {
//                    //remove picture by id
//                },
//                error: function () {

//                }
//            });
//        }

//    });
//});

//$(document).ready(function () {
//    $("#userServices").css("visibility", "hidden");
//    $('#userServices').append("<i> Please wait while we verify your authenticated services! =) </i>")
//});

//function makeClickable() {
//    $("#userServices").css("visibility", "visible");
//    $('#userServices').remove("<i> Please wait while we verify your authenticated services! =) </i>")
//}

function getVals() {
    // Get slider values
    var parent = this.parentNode;
    var slides = parent.getElementsByTagName("input");
    var slide1 = parseFloat(slides[0].value);
    var slide2 = parseFloat(slides[1].value);
    // Neither slider will clip the other, so make sure we determine which is larger
    if (slide1 > slide2) { var tmp = slide2; slide2 = slide1; slide1 = tmp; }

    var displayElement = parent.getElementsByClassName("rangeValues")[0];
    displayElement.innerHTML = "$ " + slide1 + "k - $" + slide2 + "k";
}

window.onload = function () {
    // Initialize Sliders
    var sliderSections = document.getElementsByClassName("range-slider");
    for (var x = 0; x < sliderSections.length; x++) {
        var sliders = sliderSections[x].getElementsByTagName("input");
        for (var y = 0; y < sliders.length; y++) {
            if (sliders[y].type === "range") {
                sliders[y].oninput = getVals;
                // Manually trigger event first time to display values
                sliders[y].oninput();
            }
        }
    }
}

function changeSearchSettings() {
    var model = {
        startAge: $('.hint-min').text(),
        endAge: $('.hint-max').text(),
        distance: $('#distanceoutput').text(),
        gender: gender,
        service: $('#userServicesDropDownAuth :selected').text()
    }
    var r = JSON.stringify(model);
    $.ajax({
        url: '/Actions/UpdateUserSearchSettings',
        method: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        traditional: true,
        data: JSON.stringify(model),
        success: function (data) {
            alert(data)
        },
        error: function (error) {
        }
    })
}
//location.replace("https://www.instagram.com/oauth/authorize?client_id=346912513373650&redirect_uri=https://localhost:49000/Actions/Test&scope=user_profile,user_media&response_type=code")




function uploadImages() {
    GetInstagramPictures();
    $(".instagram-images-wrapper").css("visibility", "visible");
    $(".instagram-images-wrapper").fadeIn();

}

var win;
var interval;
function AuthenticateInstagramAPI() {
    $.ajax({
        url: '/Actions/GetInstagramBadooSession',
        method: 'GET',
        success: function (data) {
            if (data == null) {

                win = window.open("https://www.instagram.com/oauth/authorize?client_id=346912513373650&redirect_uri=https://localhost:49000/Actions/AccessTokenAuth&scope=user_media,user_profile&response_type=code")

                interval = window.setInterval(check, 5000);
            } else {
                $.ajax({
                    url: '/Actions/GetUserInstagramMediaFromAPI',
                    method: 'GET',
                    success: function () {
                        alert("yes")
                    },
                    error: function (error) {
                    }
                })
            }
        },
        error: function (error) {
        }
    })


}

function check() {

    if (win.closed) {
        GetInstagramPictures();
        console.log("close");
        clearInterval(interval);
        $('spinner-border-instagram').show();

        $(".provider-button").css("visibility", "hidden");
    }
    console.log("passed inside check method");
}

function GetInstagramPictures() {

    $.ajax({
        type: "GET",
        url: '/Actions/GetUserInstagramMediaFromAPI',
        dataType: 'json',
        success: function (data) {
            $.each(data.instagramList, function (key, record) {
                var s = record.mediaUrl;
                $('.instagram-images').append('<div class="instagram-image"><img class="inst-img" src ="' + record.mediaUrl + '"/><div class="instagram-checkbox"><input type="checkbox" class="instagram-checkbox-input" name="instagram-input" value="' + record.mediaUrl + '" data-id="' + record.id + '"/></div></div >').fadeIn();
            })

        },
        error: function (e) {
            console.log(e.responseText);
        }
    });
}
var imagesArray = new Array();

var instagramUserId;
$(document).ready(function () {
    $('.instagram-images-wrapper').on('click', '.instagram-checkbox-input', function () {
      

        $(this).each(function () {

            if ($(this).prop("checked") == true) {
                console.log("Checkbox is checked.");
                var photoId = $(this).attr("data-id")
                var imgSrc = $(this).attr('value');
                imageObj = {
                    photoId: photoId,
                    userId: instagramUserId,
                    imageUrl: imgSrc
                }
                imagesArray.push(imageObj);
            }
            else if ($(this).prop("checked") == false) {
                var id = $(this).attr("data-id");
                imagesArray = imagesArray.filter(x => {
                    return x.photoId != id;
                })
            }
        });
        if (imagesArray.length > 0) {
            $('.upload-selected').css("pointer-events", "auto");
        } else {
            $('.upload-selected').css("pointer-events", "none");
        }
    });
});


function uploadInstagramPhotos() {

    var service = $('#userServicesDropDownAuth :selected').text()
    var models = {
        service: service,
        images: imagesArray
    }

    if (imagesArray.length > 0) {

        $(".instagram-images-wrapper").fadeOut()
        $(".instagram-images").text('');
        $.ajax({
            url: '/Actions/UploadImage',
            method: 'POST',
            data: { 'model': models },
            dataType: 'json',
            success: function (data) {
                getUpdatedImages();
                imagesArray = [];
            },
            error: function (error) {
                console.log(error)
            }
        });
    }
}

function getUpdatedImages() {

    var service = $('#userServicesDropDownAuth :selected').text()
    $.ajax({
        url: '/Actions/GetImages',
        method: 'GET',
        data: { 'service': service },
        dataType: 'json',
        success: function (data) {
            $('.userPicturesAuth').empty();
            $.each(data, function (key, record) {
                $('.userPicturesAuth').append('<div class="singleImage" data-id=' + record.photoId + '><img class= "img" src=' + record.previewUrl + '/><button class="dropdowncust butt fas fa-ellipsis-v"><div class="dropdown-contentcust"><div class="singleElement"><p>Change picture</p></div><div class="singleElement"><p onclick="deleteImage(' + record.photoId + ')">Delete picture</p></div><div class="singleElement"><p>Make private</p></div></div></button></div>');
            });
            $('.userPicturesAuth').append('<div class="addPicture"><div class="pictureSquare"><div class="addAPicture"><button class="upload-images" onclick="uploadImages()"><i class="fas fa-camera"></i></button></div></div></div>');

        },
        error: function (error) {

        }
    })
}


function getImages() {
    x6e = true;
    var image = document.getElementsByClassName('singleImage');
    if (image.length == 0) {
        var service = $('#userServicesDropDownAuth :selected').text()
        $.ajax({
            url: '/Actions/GetUser',
            method: 'GET',
            data: { 'service': service },
            dataType: 'json',
            success: function (data) {
                var s = data;
                $.each(data.images, function (key, record) {
                    $('.userPicturesAuth').append('<div class="singleImage" data-id=' + record.photoId + '><img class= "img" src=' + record.previewUrl + '/><button class="dropdowncust butt fas fa-ellipsis-v"><div class="dropdown-contentcust"><div class="singleElement"><p>Change picture</p></div><div class="singleElement"><p onclick="deleteImage(' + record.photoId + ')">Delete picture</p></div><div class="singleElement"><p>Make private</p></div></div></button></div>');
                });
                //$('.userPicturesAuth').append('<div class="addPicture"><div class="pictureSquare"><div class="camIcon"><i class="fas fa-camera fa-3x "></i><div class="addAPicture"><form id="formt" enctype="multipart/form-data"><input onchange="upload()" id="file" asp-for="Photo" type="file"/><input id="service2" asp-for="Service"/><i>Add a picture</i></form></div></div></div></div>');

                $(".singleImage").click(function () {
                    var atr = $(this).attr("data-id");
                });
                instagramUserId = data.userId;
                $('.checkOutAuth').fadeIn();
                $("#likesAuth").fadeIn();
                $("#descriptionAuth").fadeIn();
                $("#autocomplete2").val(data.location);
                $("#aboutMeInput").val(data.aboutMe);
                $('#distanceoutput').text(data.distanceMaxValue);
                //$('#distanceInput').value(data.distanceMaxValue);
                var s = data.lookingFor;
                if (data.lookingFor.length > 1) {
                    $("#Both").prop("checked", true);
                    gender.push(1);
                    gender.push(2);
                } else if (data.lookingFor[0] == 1) {
                    $("#Male").prop("checked", true);
                    gender.push(1);
                } else if (data.lookingFor[0] == 2) {
                    $("#Female").prop("checked", true);
                    gender.push(2);
                }

                distanceValue = data.distanceMaxValue;
                addServiceAsValidated(service)
            },
            error: function (error) {
                //alert(error+"11");
            }
        })

    }
}


$(document).ready(function () {
    var rad = document.genders.gender;
    var prev = null;
    for (var i = 0; i < rad.length; i++) {
        rad[i].addEventListener('change', function () {
            gender.length = 0;
            if (this.value == "Both") {
                gender.push(1);
                gender.push(2);
            } else if (this.value == "Male") {
                gender.push(1);
            } else if (this.value == "Female") {
                gender.push(2);
            }
        });
    }
});



$(document).ready(function (makeClickable) {
    $.ajax({
        type: "GET",
        url: '/Actions/GetUserServices',
        dataType: "json",
        success: function (data) {
            var userServices = data;
            $.ajax({
                url: '/Actions/CheckServicesValidation',
                method: 'POST',
                data: { 'services': data },
                dataType: "json",
                success: function (data) {
                    if (data.length == 0) {
                        $("#errorAuth").hide();
                        $('.spinner-borderAuth').show();
                        $("#pleaseWaitAuth").text("Validating, please do not refresh the page!").show();

                        $.ajax({
                            type: "POST",
                            url: '/Actions/ValidateAuthenticatedUsers',
                            data: { "services": userServices },
                            dataType: "json",
                            success: function (data) {
                                if (data.length != 0) {

                                    $('#dropDownAuthenticated').append('<select id="userServicesDropDownAuth" class="browser-default custom-select" asp-for="Service" onchange="getImages()"><option style="display:none"></option></select>');
                                }
                                $.each(data, function (key, record) {
                                    $('#userServicesDropDownAuth').append('<option>' + record + '</option>');
                                    $('.loaderAuth').hide();
                                    $("#pleaseWaitAuth").hide();
                                });
                            },
                            error: function () {
                                $("#error").show();
                                $("#error").text("Wrong username / password, please try again!");
                                $('.spinner-border').hide();
                                $("#pleaseWait").hide();
                            }

                        });
                    }
                },
                error: function (error) {
                    //alert(error+"11");
                }
            })
            makeClickable();
        },
        error: function () {

        }
    });
});

function validateUserAuth(service, username, password) {
    var service = service.options[service.selectedIndex].text;
    $.ajax({
        url: '/Actions/CheckServiceValidation',
        method: 'POST',
        data: { 'service': service },
        dataType: 'text',
        success: function (data) {
            if (data == "false") {
                $("#errorAuth").hide();
                $('.spinner-borderAuth').show();
                $("#pleaseWaitAuth").text("Validating, please do not refresh the page!").show();
                $.ajax({
                    type: "POST",
                    url: '/Actions/ValidateAuthenticatedUser',
                    data: { "username": username, "password": password, "service": service },
                    dataType: "text",
                    success: function () {

                        $('.loaderAuth').hide();
                        $("#pleaseWaitAuth").hide();
                        $('.checkOutAuth').fadeIn();
                        $("#likesAuth").fadeIn();
                        $("#descriptionAuth").fadeIn();

                        $.ajax({
                            url: '/Actions/GetUserImages',
                            method: 'GET',
                            dataType: 'json',
                            success: function (data) {

                                $.each(data, function (key, record) {
                                    $('.userPicturesAuth').append('<div class="singleImage" data-id=' + record.photoId + '><img class= "img" src=' + record.previewUrl + '/><button class="dropdowncust butt fas fa-ellipsis-v"><div class="dropdown-contentcust"><div class="singleElement"><p>Change picture</p></div><div class="singleElement"><p>Delete picture</p></div><div class="singleElement"><p>Make private</p></div></div></button></div>');
                                });
                                $('.userPicturesAuth').append('<div class="addPicture"><div class="pictureSquare"><div class="camIcon"><i class="fas fa-camera fa-3x "></i><div class="addAPicture"><form id="formt" enctype="multipart/form-data"><input onchange="upload()" id="file" asp-for="Photo" type="file"/><input id="service2" asp-for="Service"/><i>Add a picture</i></form></div></div></div></div>');

                                $(".singleImage").click(function () {
                                    var atr = $(this).attr("data-id");
                                    console.log(atr);
                                });

                                addServiceAsValidated(service)
                            },
                            error: function (error) {
                                //alert(error+"11");
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
        },
        error: function (error) {
            //alert(error+"11");
        }
    })

}

function addServiceAsValidated(service) {
    var val = service.value;
    $.ajax({
        url: '/Actions/AddServiceAsValidated',
        method: 'POST',
        data: val,
        dataType: 'text',
        success: function (data) {
            alert(data);
        },
        error: function (error) {
            //alert(error+"11");
        }
    })
}
function scheduleAuth() {
    $.ajax({
        type: "POST",
        url: '/Actions/Schedule',
        data: $("#schedulerFormAuth").serialize(),
        success: function () {
        },
        error: function () {
        }
    });
}
function aboutMeAuth() {
    var service = $('#userServicesDropDownAuth :selected').text()
    $('.spinner-borderAuth').show();
    $.ajax({
        type: "POST",
        url: '/Actions/ChangeAboutMe',
        data: $("#aboutMeAuth").serialize(),
        success: function () {
            $("#aboutMeInput").text(document.getElementById('aboutMeInput').value);
        },
        error: function () {

        }
    });
}

function getCityAuth() {
    var service = $('#userServicesDropDownAuth :selected').text()
    $('.spinner-borderAuth').show();
    $.ajax({
        type: "GET",
        url: '/Actions/GetCountry',
        data: $("#autocomplete2").serialize(),
        dataType: "text",
        success: function (data) {
            $.ajax({
                url: '/Actions/GetUser',
                method: 'GET',
                data: { 'service': service },
                dataType: 'json',
                success: function (data) {
                    $('.spinner-borderAuth').hide();
                    $("#currentLocation").text(document.getElementById('autocomplete2').value);
                },
                error: function (error) {
                    //alert(error+"11");
                }
            })
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
$(document).ready(function () {
    $("#likesInputAuth").change({


    })
});


function submitValidatedFormAuth(username, password) {
    var localService = document.getElementById("userServicesDropDownAuth");
    $("#checkboxAuth").fadeOut("slow", "linear")
    $("#likesAuth").fadeOut("slow", "linear");
    $("#dateAuth").fadeOut("slow", "linear");
    $("#serviceAuth").fadeOut("slow", "linear")
    validateUserAuth(username, password, service);

    likes = document.getElementById('likesInputAuth');
    service = localService;
    time = document.getElementById('datetimepicker1Auth');

};

$(document).ready(function () {
    $('.onoffswitch-checkboxAuth').on("change", slideDateAuth);
});

function slideDateAuth() {

    if ($(this).prop("checked") == true) {
        $("#dateAuth").slideUp("slow", "linear").fadeOut("slow", "linear");
    }
    else if ($(this).prop("checked") == false) {
        $("#dateAuth").slideDown("slow", "linear").fadeIn("slow", "linear");
    }
};


$('.likeInput').blur(function () {
    if (!$.trim(this.value).length) { // zero-length string AFTER a trim
        $(this).parents('p').addClass('warning');
    }
});
function submitCallBackAuth() {
    console.log("bacll");
    $("#serviceLogIn").fadeIn();
}

function flipLikesAuth() {

    $("#checkboxAuth").fadeIn();
};

function flipDateAuth() {
    var ele = document.getElementById("customCheck1").checked;
    if (ele) {
        $("#date").slideDown("slow", "linear").fadeIn("slow", "linear");
    } else {
        $("#date").slideUp("slow", "linear").fadeOut("slow", "linear");
    }
};

var x6e = false;

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

