#!/bin/sh

# https://docs.datalust.co/docs/posting-raw-events

curl http://localhost:5341/api/events/raw?clef \
    -X POST \
    -H "Content-Type: application/vnd.serilog.clef" \
    -H "X-Seq-ApiKey: huVHTjPfBxMWaaPrpEKn" \
    -d '{"@l":"Information","@t":"2016-06-07T03:44:57.8532799Z","@mt":"Hello, {User} 6","User":"alice"}'
