import numpy as np
import pandas as pd
from sklearn.cluster import KMeans
import requests

# Simulated dataset (replace with SQL data extraction if needed)
data = [
	{"Id": 1, "Gender": False, "ShopURL": "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/acrylic-pull-on-moonstruck", 
	 "Style": "streetwear", "Category": "Accessory", "Shape": "Rectangle", 
	 "ImageURL": "https://qcstreetwear.ca/cdn/shop/files/b509a3888ea40764925e24d68a180c0b_1296x.jpg?v=1700172125"},
	{"Id": 2, "Gender": False, "ShopURL": "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/beanie-las-vegas-raiders-black", 
     "Style": "streetwear", "Category": "Accessory", "Shape": "Rectangle", 
     "ImageURL": "https://qcstreetwear.ca/cdn/shop/files/unnamedcopie_1296x.jpg?v=1729428533"},
    {"Id": 3, "Gender": False, "ShopURL": "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/boston-red-sox-mvp-cap-black-grey", 
     "Style": "streetwear", "Category": "Accessory", "Shape": "Rectangle", 
     "ImageURL": "https://qcstreetwear.ca/cdn/shop/files/Captured_ecran2023-07-09a12.51.15_1296x.png?v=1689624458"},
    {"Id": 4, "Gender": False, "ShopURL": "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/chicago-bulls-47-mvp-black", 
     "Style": "streetwear", "Category": "Accessory", "Shape": "Rectangle", 
     "ImageURL": "https://qcstreetwear.ca/cdn/shop/files/Captured_ecran2023-06-04a09.00.39_1296x.png?v=1686158853"},
    {"Id": 5, "Gender": False, "ShopURL": "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/cross-body-bag-black", 
     "Style": "streetwear", "Category": "Accessory", "Shape": "Rectangle", 
     "ImageURL": "https://qcstreetwear.ca/cdn/shop/files/TB0A61GB001PrimaryHighRes_1296x.png?v=1730417891"},
    {"Id": 6, "Gender": False, "ShopURL": "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/cotton-twill-army-cap-beige", 
     "Style": "streetwear", "Category": "Accessory", "Shape": "Rectangle", 
     "ImageURL": "https://qcstreetwear.ca/cdn/shop/files/Captured_ecran2024-05-09a16.56.11_1296x.png?v=1715288228"},
    {"Id": 7, "Gender": False, "ShopURL": "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/cuffed-knit-beanie-brown", 
     "Style": "streetwear", "Category": "Accessory", "Shape": "Rectangle", 
     "ImageURL": "https://qcstreetwear.ca/cdn/shop/files/WHC200BDLarge_1296x.png?v=1732455734"},
    {"Id": 8, "Gender": False, "ShopURL": "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/copy-of-dad-hat-ny-state-of-mind-radiant-brand-navy", 
     "Style": "streetwear", "Category": "Accessory", "Shape": "Rectangle", 
     "ImageURL": "https://qcstreetwear.ca/cdn/shop/products/Captured_ecran2020-05-25a14.34.04_1296x.png?v=1590431662"}
	# Add more entries here...
]

# Convert data to DataFrame
df = pd.DataFrame(data)

# Preprocess data
# One-hot encode categorical columns
df_encoded = pd.get_dummies(df, columns=["Style", "Category", "Shape"])

# Add Gender as numerical (True -> 1, False -> 0)
df_encoded["Gender"] = df["Gender"].astype(int)

# Drop non-numerical columns
features = df_encoded.drop(columns=["Id", "ShopURL", "ImageURL"])

# Apply K-Means clustering
kmeans = KMeans(n_clusters=3, random_state=42)
df["Cluster"] = kmeans.fit_predict(features)

# Function to get recommendations
def get_recommendations(article_id, num_recommendations=3):
	cluster = df.loc[df["Id"] == article_id, "Cluster"].values[0]
	recommendations = df[df["Cluster"] == cluster].sample(num_recommendations)
	return recommendations[["Id", "ShopURL", "ImageURL"]].to_dict(orient="records")

# Example: Get recommendations for article with Id=1
recommendations = get_recommendations(article_id=1)
print("\n" + "="*50)
print("Recommendations for Article ID 1:")
for rec in recommendations:
    print(f"- Article ID: {rec['Id']}")
    print(f"  Shop URL: {rec['ShopURL']}")
    print(f"  Image URL: {rec['ImageURL']}")
    print("-" * 50)
print("="*50 + "\n")
# Send recommendations to .NET API
api_url = "https://localhost:7184/api/Articles/ReceiveRecommendations"
response = requests.post(api_url, json={"articleId": 1, "recommendations": recommendations}, verify=False)

if response.status_code == 200:
    print("Recommendations sent successfully!")
else:
    print(f"Failed to send recommendations: {response.status_code}")
    print("Response content:", response.text)