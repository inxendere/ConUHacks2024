using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SearchCode : MonoBehaviour
{
    public TMP_InputField SearchBar;  // Reference to your input field
    public Transform canvasTransform;
    public GameObject ingredientButton; // button prefab
    public Transform ingredientStartPoint;
    public int verticalSpacing = 10; // Set the vertical spacing between objects

    // this could be a text file or another external file or something for future proofing
    public List<string> allIngredients;
    // public List<string> allIngredients = new List<string> { "Spinach", "Kale", "Arugula", "Swiss Chard", "Romaine Lettuce", "Collard Greens", "Mustard Greens",
    // "Bok Choy", "Iceberg Lettuce", "Endive", "Watercress", "Beet Greens", "Turnip Greens", "Radicchio", "Escarole", "Frisée", "Butter Lettuce", "Dandelion Greens",
    // "Mesclun", "Broccoli Rabe", "Carrots", "Broccoli", "Cauliflower", "Bell Peppers", "Tomatoes", "Zucchini", "Onions", "Garlic", "Potatoes", "Sweet Potatoes",
    // "Eggplant", "Mushrooms", "Corn", "Peas", "Green Beans", "Asparagus", "Brussels Sprouts", "Cucumbers", "Celery", "Squash", "Apples", "Bananas", "Oranges",
    // "Strawberries", "Blueberries", "Raspberries", "Blackberries", "Grapes", "Watermelon", "Pineapple", "Mango", "Peaches", "Plums", "Pears", "Cherries",
    // "Kiwi", "Avocado", "Papaya", "Cantaloupe", "Lemon", "Lime", "Grapefruit", "Coconut", "Rice (white)","Rice (brown)", "Quinoa", "Oats", "Barley", "Wheat", "Cornmeal",
    // "Buckwheat", "Bulgur", "Rye", "Millet", "Farro", "Amaranth", "Spelt", "Teff", "Sorghum", "Freekeh", "Couscous", "Polenta", "Wild Rice", "Triticale", "Salmon",
    // "Tuna", "Shrimp", "Cod", "Crab", "Lobster", "Mackerel", "Haddock", "Sardines", "Clams", "Oysters", "Squid", "Octopus", "Scallops", "Catfish", "Tilapia", "Halibut",
    // "Anchovies", "Mahi Mahi", "Swordfish","Chicken breast", "Chicken thigh", "Beef steak", "Beef ground", "Pork chops", "Pork loin", "Turkey", "Lamb", "Duck", "Eggs", "Tofu", "Tempeh",
    // "Seitan", "Venison", "Bison", "Rabbit", "Quail", "Edamame", "Lentils", "Chickpeas", "Black Beans", "Navy Beans", "Pinto Beans", "Basil", "Cilantro", "Mint", "Parsley",
    // "Rosemary", "Thyme", "Oregano", "Sage", "Dill", "Chives", "Cinnamon", "Nutmeg", "Cumin", "Paprika", "Curry Powder", "Turmeric", "Cardamom", "Cloves", "Coriander", "Fennel Seed",
    // "Milk", "Cheese Cheddar", "Cheese Mozzarella", "Cheese Parmesan", "Yogurt", "Butter", "Cream", "Sour Cream", "Cottage Cheese", "Cream Cheese", "Ice Cream", "Kefir", "Buttermilk", "Ghee", "Ricotta",
    // "Feta", "Brie", "Camembert", "Blue Cheese", "Gouda", "Swiss Cheese", "Provolone", "Olive Oil", "Canola Oil", "Vegetable Oil", "Coconut Oil", "Sesame Oil", "Avocado Oil",
    // "Peanut Oil", "Sunflower Oil", "Grapeseed Oil", "Corn Oil", "Soybean Oil", "Safflower Oil", "Flaxseed Oil", "Walnut Oil", "Almond Oil", "Hazelnut Oil", "Palm Oil", "Cottonseed Oil",
    // "Rice Bran Oil", "Pumpkin Seed Oil", "Spaghetti", "Penne", "Macaroni", "Fusilli", "Farfalle (Bow Tie)", "Linguine", "Fettuccine", "Ravioli", "Tortellini", "Orzo", "Basmati Rice", "Jasmine Rice",
    // "Arborio Rice", "Brown Rice", "Wild Rice", "Soba Noodles", "Udon Noodles", "Rice Noodles", "Couscous", "Quinoa Pasta", };

    private void Awake()
    {
        //     allIngredients = new List<string> { "Spinach", "Kale", "Arugula", "Swiss Chard", "Romaine Lettuce", "Collard Greens", "Mustard Greens",
        // "Bok Choy", "Iceberg Lettuce", "Endive", "Watercress", "Beet Greens", "Turnip Greens", "Radicchio", "Escarole", "Frisée", "Butter Lettuce", "Dandelion Greens",
        // "Mesclun", "Broccoli Rabe", "Carrots", "Broccoli", "Cauliflower", "Bell Peppers", "Tomatoes", "Zucchini", "Onions", "Garlic", "Potatoes", "Sweet Potatoes",
        // "Eggplant", "Mushrooms", "Corn", "Peas", "Green Beans", "Asparagus", "Brussels Sprouts", "Cucumbers", "Celery", "Squash", "Apples", "Bananas", "Oranges",
        // "Strawberries", "Blueberries", "Raspberries", "Blackberries", "Grapes", "Watermelon", "Pineapple", "Mango", "Peaches", "Plums", "Pears", "Cherries",
        // "Kiwi", "Avocado", "Papaya", "Cantaloupe", "Lemon", "Lime", "Grapefruit", "Coconut", "Rice (white)","Rice (brown)", "Quinoa", "Oats", "Barley", "Wheat", "Cornmeal",
        // "Buckwheat", "Bulgur", "Rye", "Millet", "Farro", "Amaranth", "Spelt", "Teff", "Sorghum", "Freekeh", "Couscous", "Polenta", "Wild Rice", "Triticale", "Salmon",
        // "Tuna", "Shrimp", "Cod", "Crab", "Lobster", "Mackerel", "Haddock", "Sardines", "Clams", "Oysters", "Squid", "Octopus", "Scallops", "Catfish", "Tilapia", "Halibut",
        // "Anchovies", "Mahi Mahi", "Swordfish","Chicken breast", "Chicken thigh", "Beef steak", "Beef ground", "Pork chops", "Pork loin", "Turkey", "Lamb", "Duck", "Eggs", "Tofu", "Tempeh",
        // "Seitan", "Venison", "Bison", "Rabbit", "Quail", "Edamame", "Lentils", "Chickpeas", "Black Beans", "Navy Beans", "Pinto Beans", "Basil", "Cilantro", "Mint", "Parsley",
        // "Rosemary", "Thyme", "Oregano", "Sage", "Dill", "Chives", "Cinnamon", "Nutmeg", "Cumin", "Paprika", "Curry Powder", "Turmeric", "Cardamom", "Cloves", "Coriander", "Fennel Seed",
        // "Milk", "Cheese Cheddar", "Cheese Mozzarella", "Cheese Parmesan", "Yogurt", "Butter", "Cream", "Sour Cream", "Cottage Cheese", "Cream Cheese", "Ice Cream", "Kefir", "Buttermilk", "Ghee", "Ricotta",
        // "Feta", "Brie", "Camembert", "Blue Cheese", "Gouda", "Swiss Cheese", "Provolone", "Olive Oil", "Canola Oil", "Vegetable Oil", "Coconut Oil", "Sesame Oil", "Avocado Oil",
        // "Peanut Oil", "Sunflower Oil", "Grapeseed Oil", "Corn Oil", "Soybean Oil", "Safflower Oil", "Flaxseed Oil", "Walnut Oil", "Almond Oil", "Hazelnut Oil", "Palm Oil", "Cottonseed Oil",
        // "Rice Bran Oil", "Pumpkin Seed Oil", "Spaghetti", "Penne", "Macaroni", "Fusilli", "Farfalle (Bow Tie)", "Linguine", "Fettuccine", "Ravioli", "Tortellini", "Orzo", "Basmati Rice", "Jasmine Rice",
        // "Arborio Rice", "Brown Rice", "Wild Rice", "Soba Noodles", "Udon Noodles", "Rice Noodles", "Couscous", "Quinoa Pasta", "Cabbage", };

        allIngredients = new List<string> {"Spinach", "Kale", "Arugula", "Swiss Chard", "Romaine Lettuce", "Collard Greens", "Mustard Greens",
    "Bok Choy", "Iceberg Lettuce", "Endive", "Watercress", "Beet Greens", "Turnip Greens", "Radicchio", "Escarole",
    "Frisée", "Butter Lettuce", "Dandelion Greens", "Mesclun", "Broccoli Rabe", "Carrots", "Broccoli", "Cauliflower",
    "Bell Peppers", "Tomatoes", "Zucchini", "Onions", "Garlic", "Potatoes", "Sweet Potatoes", "Eggplant", "Mushrooms",
    "Corn", "Peas", "Green Beans", "Asparagus", "Brussels Sprouts", "Cucumbers", "Celery", "Squash", "Apples",
    "Bananas", "Oranges", "Strawberries", "Blueberries", "Raspberries", "Blackberries", "Grapes", "Watermelon",
    "Pineapple", "Mango", "Peaches", "Plums", "Pears", "Cherries", "Kiwi", "Avocado", "Papaya", "Cantaloupe",
    "Lemon", "Lime", "Grapefruit", "Coconut", "Rice (white)","Rice (brown)", "Quinoa", "Oats", "Barley", "Wheat",
    "Cornmeal", "Buckwheat", "Bulgur", "Rye", "Millet", "Farro", "Amaranth", "Spelt", "Teff", "Sorghum", "Freekeh",
    "Couscous", "Polenta", "Wild Rice", "Triticale", "Salmon", "Tuna", "Shrimp", "Cod", "Crab", "Lobster", "Mackerel",
    "Haddock", "Sardines", "Clams", "Oysters", "Squid", "Octopus", "Scallops", "Catfish", "Tilapia", "Halibut",
    "Anchovies", "Mahi Mahi", "Swordfish","Chicken breast", "Chicken thigh", "Beef steak", "Beef ground", "Pork chops",
    "Pork loin", "Turkey", "Lamb", "Duck", "Eggs", "Tofu", "Tempeh", "Seitan", "Venison", "Bison", "Rabbit", "Quail",
    "Edamame", "Lentils", "Chickpeas", "Black Beans", "Navy Beans", "Pinto Beans", "Basil", "Cilantro", "Mint",
    "Parsley", "Rosemary", "Thyme", "Oregano", "Sage", "Dill", "Chives", "Cinnamon", "Nutmeg", "Cumin", "Paprika",
    "Curry Powder", "Turmeric", "Cardamom", "Cloves", "Coriander", "Fennel Seed", "Milk", "Cheese Cheddar",
    "Cheese Mozzarella", "Cheese Parmesan", "Yogurt", "Butter", "Cream", "Sour Cream", "Cottage Cheese",
    "Cream Cheese", "Ice Cream", "Kefir", "Buttermilk", "Ghee", "Ricotta", "Feta", "Brie", "Camembert", "Blue Cheese",
    "Gouda", "Swiss Cheese", "Provolone", "Olive Oil", "Canola Oil", "Vegetable Oil", "Coconut Oil", "Sesame Oil",
    "Avocado Oil", "Peanut Oil", "Sunflower Oil", "Grapeseed Oil", "Corn Oil", "Soybean Oil", "Safflower Oil",
    "Flaxseed Oil", "Walnut Oil", "Almond Oil", "Hazelnut Oil", "Palm Oil", "Cottonseed Oil", "Rice Bran Oil",
    "Pumpkin Seed Oil", "Spaghetti", "Penne", "Macaroni", "Fusilli", "Farfalle (Bow Tie)", "Linguine", "Fettuccine",
    "Ravioli", "Tortellini", "Orzo", "Basmati Rice", "Jasmine Rice", "Arborio Rice", "Brown Rice", "Wild Rice",
    "Soba Noodles", "Udon Noodles", "Rice Noodles", "Couscous", "Quinoa Pasta", "Cabbage", "Brussels Sprouts",
    "Artichokes", "Leeks", "Radishes", "Fennel", "Turnips", "Kohlrabi", "Rutabaga", "Beets", "Butternut Squash",
    "Acorn Squash", "Pumpkin", "Spaghetti Squash", "Kabocha Squash", "Delicata Squash", "Pomegranate", "Cranberries",
    "Mangoes", "Pine Nuts", "Chestnuts", "Hazelnuts", "Almonds", "Walnuts", "Pecans", "Pistachios", "Cashews",
    "Sunflower Seeds", "Pumpkin Seeds", "Chia Seeds", "Flaxseeds", "Sesame Seeds", "Poppy Seeds", "Hemp Seeds",
    "Quince", "Persimmon", "Guava", "Passion Fruit", "Dragon Fruit", "Star Fruit", "Gooseberries", "Elderberries",
    "Mulberries", "Boysenberries", "Lychee", "Nectarines", "Apricots", "Dates", "Prunes", "Figs", "Cherimoya",
    "Star Anise", "Juniper Berries", "Allspice", "Bay Leaves", "Caraway Seeds", "Celery Seeds", "Mustard Seeds",
    "Black Mustard Seeds", "Brown Mustard Seeds", "Yellow Mustard Seeds", "Poppy Seeds", "Sesame Seeds",
    "Sunflower Seeds", "Pumpkin Seeds", "Flaxseeds", "Hemp Seeds", "Chia Seeds", "Pine Nuts", "Chestnuts",
    "Hazelnuts", "Almonds", "Bread", "Toast" };

    }

    private void Start()
    {
        SearchBar.onValueChanged.AddListener(OnSearchValueChanged);
    }

    // Call this method whenever the text in your search bar changes
    public void OnSearchValueChanged(string searchText)
    {

        if (searchText == "" || searchText == null) return;

        string searchTermLower = searchText.ToLower();

        GameObject[] gameObjectsWithTag = GameObject.FindGameObjectsWithTag("IngredientButtonTAG");

        // Loop through and destroy each GameObject
        foreach (GameObject gameObjectWithTag in gameObjectsWithTag)
        {
            Destroy(gameObjectWithTag);
        }

        // List to store relevant ingredients
        var relevantIngredients = new List<string>();

        // Iterate through all ingredients
        foreach (string ingredient in allIngredients)
        {
            // Convert current ingredient to lowercase for case-insensitive comparison
            string ingredientLower = ingredient.ToLower();

            // Check if the search term is contained in the current ingredient
            if (ingredientLower.Contains(searchTermLower))
            {
                // Add relevant ingredient to the list
                relevantIngredients.Add(ingredient);
            }
        }

        // Print relevant ingredients to Unity debug log
        // Debug.Log("Relevant Ingredients for '" + searchText + "': " + string.Join(", ", relevantIngredients));

        int i = 0;

        foreach (string ingredient in relevantIngredients)
        {
            // Debug.Log(ingredient);

            // Vector3 newPosition = ingredientStartPoint.position + Vector3.down * i * verticalSpacing;

            // GameObject ingredientButtonObject = Instantiate(ingredientButton, ingredientStartPoint);
            // ingredientButtonObject.GetComponentInChildren<TextMeshProUGUI>().text = ingredient;

            GameObject instantiatedUIObject = Instantiate(ingredientButton, ingredientStartPoint);
            instantiatedUIObject.GetComponentInChildren<TextMeshProUGUI>().text = ingredient;

            // Access RectTransform of the instantiated UI object
            RectTransform rectTransform = instantiatedUIObject.GetComponent<RectTransform>();

            // Calculate the new anchored position for each UI object
            Vector2 newAnchoredPosition = new Vector2(0, -i * verticalSpacing);

            // Debug.Log(-i * verticalSpacing);

            // Set the anchored position
            rectTransform.anchoredPosition = newAnchoredPosition;

            i += 12;
        }
    }

    // private void SearchIngredients(string searchTerm)
    // {
    //     if (searchTerm == "" || searchTerm == null) return;
    //     // Convert search term to lowercase for case-insensitive search
    //     string searchTermLower = searchTerm.ToLower();

    //     // List to store relevant ingredients
    //     var relevantIngredients = new System.Collections.Generic.List<string>();

    //     // Iterate through all ingredients
    //     foreach (string ingredient in allIngredients)
    //     {
    //         // Convert current ingredient to lowercase for case-insensitive comparison
    //         string ingredientLower = ingredient.ToLower();

    //         // Check if the search term is contained in the current ingredient
    //         if (ingredientLower.Contains(searchTermLower))
    //         {
    //             // Add relevant ingredient to the list
    //             relevantIngredients.Add(ingredient);
    //         }
    //     }

    //     // Print relevant ingredients to Unity debug log
    //     Debug.Log("Relevant Ingredients for '" + searchTerm + "': " + string.Join(", ", relevantIngredients));
    // }
}
