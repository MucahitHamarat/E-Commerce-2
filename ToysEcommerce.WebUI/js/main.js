//$(document).ready(function () {
//    $(".sliderOwl").owlCarousel(
//        {
//            items: 1
//        }
//    );
//    $(".productOwl").owlCarousel(
//        {
//            responsive: {
//                0: {
//                    items: 1
//                },
//                400: {
//                    items: 2
//                },
//                750: {
//                    items: 3
//                },
//                1100: {
//                    items: 4
//                }
//            }
//        }
//    );
//});
function Kontrol() {
    if ($(".txtName").val() == "") { alert("boş geçilemez"); return false; }
    else return true;
}