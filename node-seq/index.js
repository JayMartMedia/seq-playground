// https://docs.datalust.co/docs/using-nodejs

// imports
const winston = require('winston');
const { SeqTransport } = require('@datalust/winston-seq');

// configure winston logger
const logger = winston.createLogger({
    format: winston.format.combine(  /* This is required to get errors to log with stack traces. See https://github.com/winstonjs/winston/issues/1498 */
        winston.format.errors({ stack: true }),
        winston.format.json(),
    ),
    transports: [
        // add seq transport to winston logger in order to send logs to seq
        new SeqTransport({
            // only logs equal to or more severe than info will go to seq
            // (this means debug logs will not go to seq)
            level: "info",
            serverUrl: "http://localhost:5341",
            apiKey: "2sHFo0b5HoHLTLqapKDe",
            onError: (e => { console.error(e) }),
        }),
        // add console transport to winston logger in order to send logs to console output
        new winston.transports.Console({
            format: winston.format.simple()
        })
    ]
});

// produce logs
logger.info('Here is an info log from {userId}', {userId: 'testUser', userId2: 'testUser2'});
logger.debug('Here is a debug log that will go to console, but not to SEQ');
logger.error('Here is an error log');
