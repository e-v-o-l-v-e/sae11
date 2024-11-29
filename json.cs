public static string Rounds(Player player1, Player player2) {
        string rounds = "";
        for (int i = 0; i < 13; i++) { // Afficher 13 rounds
            rounds += "    {\n" +
                      "      \"id\": " + (i + 1) + ",\n" + // ID des rounds commence à 1
                      "      \"results\": [\n" +
                      "        {\n" +
                      "          \"id_player\": " + player1.id + ",\n" +
                      "          \"dice\": [" + Des(player1.dices, i) + "],\n" +
                      "          \"challenge\": \"" + ChallengeName(player1.challTour[i]) + "\",\n" +
                      "          \"score\": " + player1.scoreRounds[i] + "\n" +
                      "        },\n" +
                      "        {\n" +
                      "          \"id_player\": " + player2.id + ",\n" +
                      "          \"dice\": [" + Des(player2.dices, i) + "],\n" +
                      "          \"challenge\": \"" + ChallengeName(player2.challTour[i]) + "\",\n" +
                      "          \"score\": " + player2.scoreRounds[i] + "\n" +
                      "        }\n" +
                      "      ]\n" +
                      "    }";

            if (i < 12) { // Ajouter une virgule sauf pour le dernier round
                rounds += ",";
            }
            rounds += "\n";
        }
        return rounds;
    }

    public static string Des(int[,] dices, int round) {
        string res = "";
        for (int i = 0; i < dices.GetLength(1); i++) {
            res += dices[round, i];
            if (i < dices.GetLength(1) - 1) {
                res += ", ";
            }
        }
        return res;
    }

    public static string ChallengeName(int challengeId) {
        string[] challenges = { "nombreDe1","nombreDe2","nombreDe3","nombreDe4","nombreDe5","nombreDe6","brelan","carre","full","petiteSuite","grandeSuite","yams","chance" };
        return challenges[challengeId];
    }

    public static string FinalResult(Player player1, Player player2) {
        return "    {\n" +
               "      \"id_player\": " + player1.id + ",\n" +
               "      \"bonus\": " + player1.bonus + ",\n" +
               "      \"score\": " + player1.scoreTotal + "\n" +
               "    },\n" +
               "    {\n" +
               "      \"id_player\": " + player2.id + ",\n" +
               "      \"bonus\": " + player2.bonus + ",\n" +
               "      \"score\": " + player2.scoreTotal + "\n" +
               "    }";
    }
