function selectTemplateType(idValue) {
    $('#templateTypeContainer>button').removeClass("selected");
    $('#templateTypeContainer button:nth-child(' + idValue + ')').addClass("selected");

    // if select answer sheet
    if (idValue === "1") {
        $("#questionNumContainer").show('fast');
    } else {
        $("#questionNumContainer").hide('fast');
    }
}
function showToast(msg) {
	var toast = $('.toast');
	if (toast.length <= 0) {
		toast = $('<div class="toast" role="alert" aria-live="assertive" aria-atomic="true" data-delay="2000" style="position: fixed; top: 5rem; right: 4rem;"><div class="toast-body">Hello</div></div>');
	}
	toast.find('.toast-body').text(msg);
	$('body').append(toast);
	toast.toast('show');
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

function selectOutput(output) {
    $('#outputFormatContainer>button').removeClass("selected");
    $('#outputFormatContainer button:nth-child(' + output + ')').addClass("selected");
}

function selectQuestionNum(qNum) {
    $('#questionNum>button').removeClass("selected");
    $('#questionNum button:nth-child(' + qNum + ')').addClass("selected");
}

function copyToClibpoard() {
    checkAnadReportAnalytics('copyOmrResult');

    var copyText = document.getElementById("recognitionResult");
    var $temp = $("<input>");
    $("body").append($temp);
    $temp.val($(copyText).text()).select();
    document.execCommand("copy");
    $temp.remove();
    alert("The text is copied to clipboard.");
}

var file = null;

function scanOMRImageLegacy()
{
    var templateType = parseInt($('#templateTypeContainer>button.selected').val());
    if (typeof templateType === 'undefined') {
        templateType = 0;
    }
    // fix to use zero based template types 
    templateType--;
    scanOMRImage(templateType);
}

function scanOMRImage(templateType) {
    var qNum;

    checkAnadReportAnalytics('scanOmrImage');

    // if answer sheet selected, parse num of questions
    if (templateType === 0) {
        qNum = $('#questionNum>button.selected').val();
        if (typeof qNum === 'undefined') {
            qNum = "1";
        }
    } else {
        qNum = null;
    }

    var outputFormat = $('#outputFormatContainer>button.selected').val();
    if (typeof outputFormat === 'undefined') {
        outputFormat = 1;
    }

    if (file) {
        if (window.FormData !== undefined) {
            var data = new FormData();
            data.append("templateType", templateType);
            data.append("outputFormat", outputFormat);
            data.append("questionsNumber", qNum);
            data.append("file", file);

            $("#recognitionLoader").show();
            hideResBlock();

            $.ajax({
                type: "POST",
                url: "scan",
                contentType: false,
                processData: false,
                data: data
            }).done(function(result) {
                if (!result.success) {
                    $('#recognitionResult>pre').html(result.errorMsg);
                } else {
                    $('#recognitionResult>pre').html(result.text);
                    $("#omrDownloadButton").click(function () {
                        checkAnadReportAnalytics('downloadOmrResult');
                        window.location = result.url;
                    });
                }
            }).always(function() {
                $("#recognitionLoader").hide();
                $('#recognitionResult').show();
                $('#OMRResultBlock').show();
            });

        } else {
            showToast("Something went wrong! Please try again.");
        }
    } else {
        showToast("No image was uploaded! Please upload image to recognize.");
    }
}

function hideResBlock() {
    $('#recognitionResult').hide();
    $('#OMRResultBlock').hide();
}

function removefile() {
    $('.fileupload').hide();
    $('.uploadfileinput').show();
}

$(document).ready(function () {
    $('.fileupload').hide();

    $("#recognitionLoader").hide();
    $('#recognitionResult').hide();

    $('#OMRResultBlock').hide();
    $('#templateTypeContainer button:nth-child(' + 1 + ')').addClass("selected");

    $("#omrUploadFile").change(function (e) {
        if (e.target.files.length > 0) {

            // check and report
            if (typeof window.gtag == 'function'){
                window.gtag('event', 'uploadOmrFile', {
                    'event_category': 'dropdown'
                });
            }

            $('#recognitionResult>pre').html("");
            hideResBlock();
            file = e.target.files[0];

            $('#fileNameLabel').text(file.name);
            $('.fileupload').show();
        }
    });
});
