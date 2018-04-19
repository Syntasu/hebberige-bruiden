/// <binding BeforeBuild='compile-less, minify-css' />
var gulp = require("gulp"),
    less = require("gulp-less"),
    min = require("gulp-cleancss");

gulp.task("compile-less", function ()
{
    return gulp.src('Less/*.less')
        .pipe(less())
        .pipe(gulp.dest("Less/compiled"))
});

gulp.task('minify-css', function ()
{
    return gulp.src('Less/compiled/*.css')
        .pipe(min({ compatibility: 'ie8' }))
        .pipe(gulp.dest('Stylesheets'));
});
