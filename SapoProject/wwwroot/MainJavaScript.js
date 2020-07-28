$(document).ready(function () {
	CKEDITOR.replace("noidung");
	$("#selectImg").click(function () {
		console.log("adhajdjasdbjasdajdajdnajdnsaj");
		var finder = new CKFinder();
		finder.selectActionFunction = function (baseUrl) {
			baseUrl = baseUrl.substring(baseUrl.lastIndexOf("/") + 1);
			$("#linking").val(baseUrl);

		};
		finder.popup();

	});
});

//upload image 
$(document).ready(function () {
	$('.custom-file-input').on("change", function () {
		console.log("aaaaaaaaaaaaaaa");
		var fileName = $(this).val().split("\\").pop();
		$(this).next('.custom-file-label').html(fileName);
	});
});
function readURL(input) {
	if (input.files && input.files[0]) {
		var reader = new FileReader();

		reader.onload = function (e) {
			$('#blah')
				.attr('src', e.target.result);
		};

		reader.readAsDataURL(input.files[0]);
	}
}
	/*function BrowseServer()
{

	console.log("asdsdsdsd");
// You can use the "CKFinder" class to render CKFinder in a page:
var finder = new CKFinder();
finder.basePath = '../';	// The path for the installation of CKFinder (default = "/ckfinder/").
finder.selectActionFunction = SetFileField;
finder.popup();

// It can also be done in a single line, calling the "static"
// popup( basePath, width, height, selectFunction ) function:
// CKFinder.popup( '../', null, null, SetFileField ) ;
//
// The "popup" function can also accept an object as the only argument.
// CKFinder.popup( {basePath : '../', selectActionFunction : SetFileField } ) ;
}

// This is a sample function which is called when a file is selected in CKFinder.
function SetFileField( fileUrl )
{
	document.getElementById('xFilePath').value = fileUrl;
}		   */

