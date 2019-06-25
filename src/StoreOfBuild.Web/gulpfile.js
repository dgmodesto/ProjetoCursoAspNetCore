var gulp = require('gulp');
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');
var uncss = require('gulp-uncss');
var browserSync = require('browser-sync').create();

gulp.task("js", function() {
    return gulp.src([
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.js',
        './node_modules/jquery-ajax-unobtrusive/dist/jquery.unobtrusive-ajax.min.js',
        './js/site.js',
    ])
    .pipe(gulp.dest('wwwroot/js/'))
    .pipe(browserSync.stream());
});

gulp.task('css', function(){
    return gulp.src([
        './node_modules/bootstrap/dist/css/bootstrap.css',
        './styles/site.css'
    ])
    .pipe(concat('site.min.css'))
    .pipe(cssmin())
    .pipe(uncss({ html: ['Views/**/*.cshtml']}))
    .pipe(gulp.dest('wwwroot/css/'))
    .pipe(browserSync.stream());
});

gulp.task('browser-sync', function(){
    browserSync.init({
        proxy: 'https://localhost:5001'
    });

    gulp.watch('./styles/*.css', gulp.series('css'))
    gulp.watch('./js/*.js', gulp.series('js'))
});