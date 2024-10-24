/*
### Spécifications :
#### Collection de livres :
- Utilisez une liste pour stocker les livres. Chaque livre doit avoir les informations suivantes : titre, status (disponible ou date de retour).
#### Fonctions:
Chaque fonctionnalité doit avoir sa propre fonction vous devriez donc au minimum avoir les fonctions suivantes:
1. **AfficherTousLesLivres**: Cette fonction parcourt la collection de livres et affiche leurs titre et leur disponibilité.  Si le livre est disponible, afficher "Disponible" sinon afficher la date de retour.
2. **RechercherParTitre**: Cette fonction prend un chaine en paramètre et renvoie tous les livres dont le titre contient la chaine recherché sans tenir compte de la case.
3. **EmprunterLivre**: Cette fonction permet de simuler l'emprunt d'un livre. Elle prend le numéro (position) du livre en paramètre, vérifie s'il est disponible, et si c'est le cas, assigne une date de retour 3 semaine plus tard que la date actuel. La fonction retourne ensuite vrai ou faux en fonction de si le livre a pu être emprunté.
4. **RetournerLivre**: Cette fonction permet de simuler le retour d'un livre.  Elle prend le numéro (position) du livre en paramètre et rend celui-ci disponible.

#### Input/output
- Programmer un menu de 5 options.  Les 4 opérations principales ainsi qu'une option "Quitter".
- Pour chaque options, collecter **et valider** les données nécéssaires à l'appel de la fonction à l'aide d'entrée et afficher en sortie l'information nécéssaire à l'utilisateur dans la console.

### Exigences techniques :
- Implémentez des fonctions pour chacune des opérations.
- Respecter les principes SOLID.
- Utilisez de votre mieux les try-catch pour valider les entrées et gérer les cas d'exceptions évident.
*/

List<string> books = ["Lord of the ring", "Harry Potter", "The Hobbit", "The Alchemist", "The Catcher in the Rye", "The Great Gatsby", "The Lion, the Witch and the Wardrobe", "The Outsiders"];
List<string> returnDate = ["Disponible", "Disponible", "2024-10-29", "Disponible", "2024-10-27", "Disponible", "Disponible", "Disponible"];

void AfficherMenu()
{
    Console.WriteLine("=============== Menu ===============");
    Console.WriteLine("1. Afficher tous les livres");
    Console.WriteLine("2. Rechercher un livre");
    Console.WriteLine("3. Emprunter un livre");
    Console.WriteLine("4. Retourner un livre");
    Console.WriteLine("5. Quitter");
    Console.WriteLine("====================================");
}

int ReadInt(){
    try{
        return Convert.ToInt32(Console.ReadLine());
    }
    catch(Exception){    
        Console.WriteLine("Veuillez entrer un nombre valide.");
        return ReadInt();
    }
}

void RechercherParTitre(){
    Console.WriteLine("Entrez le titre du livre : ");
    string title = Console.ReadLine();
    for (int i = 0; i < books.Count; i++)    {
        if (books[i].ToLower().Contains(title.ToLower())){
            Console.WriteLine($"#{i+1} - {books[i]} - {returnDate[i]}");
        }
    }
}

void AfficherTousLesLivres(){
    for (int i = 0; i < books.Count; i++)    {
        Console.WriteLine($"#{i+1} - {books[i]} - {returnDate[i]}");
    }
}

bool EmprunterLivre(){
    try{
        Console.WriteLine("Entrez le numéro du livre : ");
        int index = ReadInt();
        if (returnDate[index-1] == "Disponible")        {
            returnDate[index-1] = DateTime.Now.AddDays(21).ToString("yyyy-MM-dd");
            return true;
        }
        return false;
    }
    catch(Exception){
        Console.WriteLine($"Veuillez entrer un nombre entre 1 et {books.Count}.");
        return EmprunterLivre();
    }
}

void RetournerLivre(){
    try{
        Console.WriteLine("Entrez le numéro du livre : ");
        int index = ReadInt();
        returnDate[index-1] = "Disponible";
    }
    catch(Exception){
        Console.WriteLine($"Veuillez entrer un nombre entre 1 et {books.Count}.");
        RetournerLivre();
    }
}

bool exit = false;
while(!exit){
    AfficherMenu();
    int choice = ReadInt();
    Console.Clear();
    switch(choice){
        case 1:
            AfficherTousLesLivres();
            break;
        case 2:
            RechercherParTitre();
            break;
        case 3:
            if(EmprunterLivre()){
                Console.WriteLine("Le livre a été emprunté avec succès.");
            }
            else{
                Console.WriteLine("Le livre n'est pas disponible.");
            }
            break;
        case 4:
            RetournerLivre();
            Console.WriteLine("Le livre a été retourné avec succès.");
            break;
        case 5:
            exit = true;
            break;
        default:
            Console.WriteLine("Veuillez entrer un nombre entre 1 et 5.");
            break;
    }
}