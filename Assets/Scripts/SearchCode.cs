using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SearchCode : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public Transform currentTransform;
    public GameObject ContentHolder;
    public GameObject ElementPrefab;  // Prefab for displaying each element
    public TMP_InputField SearchBar;  // Reference to your input field
    public Dictionary<string, List<string>> Categories; // Stores your categories and subcategories

    // this could be a text file or another external file or something for future proofing
    public List<string> allIngredients = new List<string> { "Spinach", "Kale", "Arugula", "Swiss Chard", "Romaine Lettuce", "Collard Greens", "Mustard Greens",
    "Bok Choy", "Iceberg Lettuce", "Endive", "Watercress", "Beet Greens", "Turnip Greens", "Radicchio", "Escarole", "Frisée", "Butter Lettuce", "Dandelion Greens",
    "Mesclun", "Broccoli Rabe", "Carrots", "Broccoli", "Cauliflower", "Bell Peppers", "Tomatoes", "Zucchini", "Onions", "Garlic", "Potatoes", "Sweet Potatoes",
    "Eggplant", "Mushrooms", "Corn", "Peas", "Green Beans", "Asparagus", "Brussels Sprouts", "Cucumbers", "Celery", "Squash", "Apples", "Bananas", "Oranges",
    "Berries (strawberries, blueberries, raspberries, blackberries)", "Grapes", "Watermelon", "Pineapple", "Mango", "Peaches", "Plums", "Pears", "Cherries",
    "Kiwi", "Avocado", "Papaya", "Cantaloupe", "Lemon", "Lime", "Grapefruit", "Coconut", "Rice (white, brown)", "Quinoa", "Oats", "Barley", "Wheat", "Cornmeal",
    "Buckwheat", "Bulgur", "Rye", "Millet", "Farro", "Amaranth", "Spelt", "Teff", "Sorghum", "Freekeh", "Couscous", "Polenta", "Wild Rice", "Triticale", "Salmon",
    "Tuna", "Shrimp", "Cod", "Crab", "Lobster", "Mackerel", "Haddock", "Sardines", "Clams", "Oysters", "Squid", "Octopus", "Scallops", "Catfish", "Tilapia", "Halibut",
    "Anchovies", "Mahi Mahi", "Swordfish","Chicken (breast, thigh)", "Beef (steak, ground)", "Pork (chops, loin)", "Turkey", "Lamb", "Duck", "Eggs", "Tofu", "Tempeh",
    "Seitan", "Venison", "Bison", "Rabbit", "Quail", "Edamame", "Lentils", "Chickpeas", "Black Beans", "Navy Beans", "Pinto Beans", "Basil", "Cilantro", "Mint", "Parsley",
    "Rosemary", "Thyme", "Oregano", "Sage", "Dill", "Chives", "Cinnamon", "Nutmeg", "Cumin", "Paprika", "Curry Powder", "Turmeric", "Cardamom", "Cloves", "Coriander", "Fennel Seed",
    "Milk", "Cheese (Cheddar, Mozzarella, Parmesan, etc.)", "Yogurt", "Butter", "Cream", "Sour Cream", "Cottage Cheese", "Cream Cheese", "Ice Cream", "Kefir", "Buttermilk", "Ghee", "Ricotta",
    "Feta", "Brie", "Camembert", "Blue Cheese", "Gouda", "Swiss Cheese", "Provolone", "Olive Oil", "Canola Oil", "Vegetable Oil", "Coconut Oil", "Sesame Oil", "Avocado Oil",
    "Peanut Oil", "Sunflower Oil", "Grapeseed Oil", "Corn Oil", "Soybean Oil", "Safflower Oil", "Flaxseed Oil", "Walnut Oil", "Almond Oil", "Hazelnut Oil", "Palm Oil", "Cottonseed Oil",
    "Rice Bran Oil", "Pumpkin Seed Oil", "Spaghetti", "Penne", "Macaroni", "Fusilli", "Farfalle (Bow Tie)", "Linguine", "Fettuccine", "Ravioli", "Tortellini", "Orzo", "Basmati Rice", "Jasmine Rice",
    "Arborio Rice", "Brown Rice", "Wild Rice", "Soba Noodles", "Udon Noodles", "Rice Noodles", "Couscous", "Quinoa Pasta" };

    private void Start()
    {
        currentTransform = StartPoint;

        // PopulateElements(); // Initially populate elements

        // foreach (string ingredient in allIngredients)
        // {
        //     Debug.Log(ingredient);
        // }

        SearchBar.onValueChanged.AddListener(OnSearchValueChanged);

    }

    // Call this method whenever the text in your search bar changes
    public void OnSearchValueChanged(string searchText)
    {

    }

    private void Update()
    {

    }
}
