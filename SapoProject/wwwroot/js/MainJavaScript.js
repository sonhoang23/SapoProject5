$(document).ready(function () {
	//CKEDITOR.replace("noidung");
	$("#selectImg").click(function () {
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

$(document).ready(function () {
	console.log("11111111111111111");
	
});