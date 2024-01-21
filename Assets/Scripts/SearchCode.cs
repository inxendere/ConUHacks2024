using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchCode : MonoBehaviour
{
    public GameObject ContentHolder;
    public GameObject ElementPrefab;  // Prefab for displaying each element
    public TMP_InputField SearchBar;  // Reference to your input field
    public Dictionary<string, List<string>> Categories; // Stores your categories and subcategories

    private void Start()
    {
        // Initialize your categories here
        Categories = new Dictionary<string, List<string>>
        {
            { "Greens", new List<string> { "Spinach", "Kale", "Arugula", "Swiss Chard", "Romaine Lettuce", "Collard Greens", "Mustard Greens", "Bok Choy", "Iceberg Lettuce", "Endive", "Watercress", "Beet Greens", "Turnip Greens", "Radicchio", "Escarole", "Frisée", "Butter Lettuce", "Dandelion Greens", "Mesclun", "Broccoli Rabe" }},
            { "Vegetables", new List<string> { "Carrots", "Broccoli", "Cauliflower", "Bell Peppers", "Tomatoes", "Zucchini", "Onions", "Garlic", "Potatoes", "Sweet Potatoes", "Eggplant", "Mushrooms", "Corn", "Peas", "Green Beans", "Asparagus", "Brussels Sprouts", "Cucumbers", "Celery", "Squash" }},
            { "Fruits", new List<string> { "Apples", "Bananas", "Oranges", "Berries (strawberries, blueberries, raspberries, blackberries)", "Grapes", "Watermelon", "Pineapple", "Mango", "Peaches", "Plums", "Pears", "Cherries", "Kiwi", "Avocado", "Papaya", "Cantaloupe", "Lemon", "Lime", "Grapefruit", "Coconut" }},
            { "Grains", new List<string> { "Rice (white, brown)", "Quinoa", "Oats", "Barley", "Wheat", "Cornmeal", "Buckwheat", "Bulgur", "Rye", "Millet", "Farro", "Amaranth", "Spelt", "Teff", "Sorghum", "Freekeh", "Couscous", "Polenta", "Wild Rice", "Triticale" }},
            { "Seafood", new List<string> { "Salmon", "Tuna", "Shrimp", "Cod", "Crab", "Lobster", "Mackerel", "Haddock", "Sardines", "Clams", "Oysters", "Squid", "Octopus", "Scallops", "Catfish", "Tilapia", "Halibut", "Anchovies", "Mahi Mahi", "Swordfish" }},
            { "Meats and Proteins", new List<string> { "Chicken (breast, thigh)", "Beef (steak, ground)", "Pork (chops, loin)", "Turkey", "Lamb", "Duck", "Eggs", "Tofu", "Tempeh", "Seitan", "Venison", "Bison", "Rabbit", "Quail", "Edamame", "Lentils", "Chickpeas", "Black Beans", "Navy Beans", "Pinto Beans" }},
            { "Herbs and Spices", new List<string> { "Basil", "Cilantro", "Mint", "Parsley", "Rosemary", "Thyme", "Oregano", "Sage", "Dill", "Chives", "Cinnamon", "Nutmeg", "Cumin", "Paprika", "Curry Powder", "Turmeric", "Cardamom", "Cloves", "Coriander", "Fennel Seed" }},
            { "Dairies", new List<string> { "Milk", "Cheese (Cheddar, Mozzarella, Parmesan, etc.)", "Yogurt", "Butter", "Cream", "Sour Cream", "Cottage Cheese", "Cream Cheese", "Ice Cream", "Kefir", "Buttermilk", "Ghee", "Ricotta", "Feta", "Brie", "Camembert", "Blue Cheese", "Gouda", "Swiss Cheese", "Provolone" }},
            { "Oils", new List<string> { "Olive Oil", "Canola Oil", "Vegetable Oil", "Coconut Oil", "Sesame Oil", "Avocado Oil", "Peanut Oil", "Sunflower Oil", "Grapeseed Oil", "Corn Oil", "Soybean Oil", "Safflower Oil", "Flaxseed Oil", "Walnut Oil", "Almond Oil", "Hazelnut Oil", "Palm Oil", "Cottonseed Oil", "Rice Bran Oil", "Pumpkin Seed Oil" }},
            { "Pasta and Rices", new List<string> { "Spaghetti", "Penne", "Macaroni", "Fusilli", "Farfalle (Bow Tie)", "Linguine", "Fettuccine", "Ravioli", "Tortellini", "Orzo", "Basmati Rice", "Jasmine Rice", "Arborio Rice", "Brown Rice", "Wild Rice", "Soba Noodles", "Udon Noodles", "Rice Noodles", "Couscous", "Quinoa Pasta" }}
        };

        PopulateElements(); // Initially populate elements
    }

    // Call this method whenever the text in your search bar changes
    public void OnSearchValueChanged(string searchText)
    {
        // Clear previous elements
        foreach (Transform child in ContentHolder.transform)
        {
            Destroy(child.gameObject);
        }

        // Filter and display the elements based on the search text
        foreach (KeyValuePair<string, List<string>> category in Categories)
        {
            if (string.IsNullOrEmpty(searchText) || category.Key.ToLower().Contains(searchText.ToLower()))
            {
                // If search text is empty or the category contains the search text, display all subcategories
                AddCategoryElement(category.Key);
                foreach (string subCategory in category.Value)
                {
                    AddSubCategoryElement(subCategory);
                }
            }
            else
            {
                // Check subcategories
                foreach (string subCategory in category.Value)
                {
                    if (subCategory.ToLower().Contains(searchText.ToLower()))
                    {
                        AddCategoryElement(category.Key);
                        AddSubCategoryElement(subCategory);
                        break; // Break since we only want to add this category once
                    }
                }
            }
        }
    }

    // Method to populate elements based on categories and subcategories
    private void PopulateElements()
    {
        foreach (KeyValuePair<string, List<string>> category in Categories)
        {
            AddCategoryElement(category.Key);
            foreach (string subCategory in category.Value)
            {
                AddSubCategoryElement(subCategory);
            }
        }
    }

    // Adds a category element to the UI
    private void AddCategoryElement(string categoryName)
    {
        GameObject newElement = Instantiate(ElementPrefab, ContentHolder.transform);
        newElement.GetComponent<TMP_Text>().text = categoryName; // Set the text for the element
        newElement.name = "Category: " + categoryName; // Optional: name the GameObject for easy identification
        // Set additional properties and styles specific to categories if needed
    }

    // Adds a subcategory element to the UI
    private void AddSubCategoryElement(string subCategoryName)
    {
        GameObject newElement = Instantiate(ElementPrefab, ContentHolder.transform);
        newElement.GetComponent<TMP_Text>().text = " - " + subCategoryName; // Set the text for the element
        newElement.name = "SubCategory: " + subCategoryName; // Optional: name the GameObject for easy identification
        // Set additional properties and styles specific to subcategories if needed
    }
}
