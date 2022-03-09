# Spotify consumes the Spotify API 
First a post request is send to the server with the given client id and client secret.
On getting 200 i.e. Ok response, authentication is completed and the process is closed

Then again a Get request is send to the server To get all new releases of a particular country whose country code is passed in the arguments.
If the releases are found 202 Ok response is returned. Else 404 Not found is returned.

This repo is for practice purpose only in order to understand and get familiar with REST API and its working. 
