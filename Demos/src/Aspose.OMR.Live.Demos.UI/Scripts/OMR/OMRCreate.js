function selectTemplateType(idValue, imgUrl, typeDescription1, typeDescription2, typeDescription3) {
    $('#templateTypeContainer>button').removeClass("selected");
    $('#templateTypeContainer button:nth-child(' + idValue + ')').addClass("selected");

    // if select answer sheet
    if (idValue === "1") {
        $("#questionNumContainer").show();
        $('#questionNum>button').removeClass("selected");
        $('#questionNum button:nth-child(' + 2 + ')').addClass("selected");
    } else {
        $("#questionNumContainer").hide();
    }

    hideResultsContainer();

    document.getElementById("omrImage").src = imgUrl;
    updateTemplateDescriptionList(typeDescription1, typeDescription2, typeDescription3);
}

function selectQuestionNum(qNum, imgUrl) {
    $('#questionNum>button').removeClass("selected");
    $('#questionNum button:nth-child(' + qNum + ')').addClass("selected");

    document.getElementById("omrImage").src = imgUrl;

    hideResultsContainer();
}

function selectOutput(output) {
    $('#outputFormatContainer>button').removeClass("selected");
    $('#outputFormatContainer button:nth-child(' + output + ')').addClass("selected");

    hideResultsContainer();
}

// update list with template description according to changed template type
function updateTemplateDescriptionList(typeDescription1, typeDescription2, typeDescription3) {
    $("#templateDescList").empty();
    var ul = document.getElementById("templateDescList");

    var listItem1 = document.createElement("li");
    listItem1.classList.add("omrListItem");
    listItem1.textContent = typeDescription1;
    ul.appendChild(listItem1);

    var listItem2 = document.createElement("li");
    listItem2.classList.add("omrListItem");
    listItem2.textContent = typeDescription2;
    ul.appendChild(listItem2);

    var listItem3 = document.createElement("li");
    listItem3.classList.add("omrListItem");
    listItem3.textContent = typeDescription3;
    ul.appendChild(listItem3);
}

// hide results area with download button and links
function hideResultsContainer() {
    $("#omrResultContainer").hide();
    $("#omrRecognizeLink").hide();
}

function checkAnadReportAnalytics(actionName) {
    // check if gtag loaded
    if (typeof window.gtag == 'function') {
        // report event to google analytics
        window.gtag('event', actionName, {
            'event_category': 'buttonClick'
        });
    }
}

// legacy function for Create app
function generateTemplateLegacy() {

    checkAnadReportAnalytics('createOmrImageLegacy');

    // parse template type
    var templateTypeInt = parseInt($('#templateTypeContainer>button.selected').val());
    if (typeof templateTypeInt === 'undefined') {
        templateTypeInt = 0;
    }

    // fix to use zero based template types 
    templateTypeInt--;
    generateTemplate(templateTypeInt);
}

// common function to create all types of template (sheet, survey, test)
// passed parameter from UI button describes required type of template
function generateTemplate(templateType) {
    var qNum, outputFormat;

    checkAnadReportAnalytics('createOmrImage');

    // if answer sheet selected, parse num of questions
    if (templateType === 0) {
        qNum = $('#questionNum>button.selected').val();
        if (typeof qNum === 'undefined') {
            qNum = "1";
        }
    } else {
        qNum = null;
    }

    // parse output type
    outputFormat = $('#outputFormatContainer>button.selected').val();
    if (typeof outputFormat === 'undefined') {
        outputFormat = "1";
    }

    $("#omrLoader").show();

    $.ajax({
        type: 'POST',
        url: "create",
        data: {
            templateType: templateType,
            outputFormat: outputFormat,
            questionsNumber: qNum
        }
    }).done(function (res) {
        if (res.success) {
            $("#omrDownloadButton").click(function () {
                checkAnadReportAnalytics('downloadOmrImage');
                window.location = res.url;
            });
            $("#omrResultContainer").show();
            $("#omrRecognizeLink").show();
        } else {
            showToast(res.errorMsg);
        }
        }).always(function () {
        $("#omrLoader").hide();
    });
}

$(document).ready(function() {
    $("#omrLoader").hide();
    $("#omrResultContainer").hide();
    $("#omrRecognizeLink").hide();

    $('#templateTypeContainer button:nth-child(' + 1 + ')').addClass("selected");
});