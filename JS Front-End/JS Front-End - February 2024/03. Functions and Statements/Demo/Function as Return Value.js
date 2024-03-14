function loggerBuilder(course) {
    return function (text) {
        console.log(`${course}: ${text}`);
    }
}

const logger = loggerBuilder('JS Front-End');
logger('Hello Ivo!');