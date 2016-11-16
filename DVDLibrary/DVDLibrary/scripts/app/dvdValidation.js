$(document)
    .ready(function() {
        $('#addDVD').validate({
            rules: {
                Title: {
                    required: true
                },
                ReleaseDate: {
                    required: true
                },
                MPAA: {
                    required: true
                },
                DirectorName: {
                    required: true
                },
                Studio: {
                    required: true
                },
                "Actors[0].FirstName": {
                    required: true
                },
                "Actors[0].LastName": {
                    required: true
                },
                "Actors[0].CharName": {
                    required: true
                },
                "Actors[1].FirstName": {
                    required: true
                },
                "Actors[1].LastName": {
                    required: true
                },
                "Actors[1].CharName": {
                    required: true
                },
                "Actors[2].FirstName": {
                    required: true
                },
                "Actors[2].LastName": {
                    required: true
                },
                "Actors[2].CharName": {
                    required: true
                },
                messages: {
                    Title: {
                        required: "What is the movie called?"
                    },
                    ReleaseDate: {
                        required: "When was it released?"
                    },
                    MPAA: {
                        required: "What is its rating?"
                    },
                    DirectorName: {
                        required: "Who directed it?"
                    },
                    Studio: {
                        required: "What studio produced it?"
                    },
                    "Actors[0].FirstName": {
                        required: "What was their first name?"
                    },
                    "Actors[0].LastName": {
                        required: "What was their last name?"
                    },
                    "Actors[0].CharName": {
                        required: "Who did the play?"
                    },
                    "Actors[1].FirstName": {
                        required: "What was their first name?"
                    },
                    "Actors[1].LastName": {
                        required: "What was their last name?"
                    },
                    "Actors[1].CharName": {
                        required: "Who did the play?"
                    },
                    "Actors[2].FirstName": {
                        required: "What was their first name?"
                    },
                    "Actors[2].LastName": {
                        required: "What was their last name?"
                    },
                    "Actors[2].CharName": {
                        required: "Who did the play?"
                    }
                }
            }

        });

    });