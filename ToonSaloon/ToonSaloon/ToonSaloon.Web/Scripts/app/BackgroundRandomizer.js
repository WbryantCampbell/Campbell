$(function () {
    var images = [ 'rickandMorty.jpg' , 'simpsons.jpg', 'transformers.jpg', 'disney.jpg', 'comics.jpg'];
    $('#background').css({ 'background-image': 'url(../../Backgrounds/' + images[Math.floor(Math.random() * images.length)] + ')' });
});
