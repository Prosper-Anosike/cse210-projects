# W04 Team Activity: Foundation Programs Design

## Program 1: YouTube Videos (Abstraction)

### Purpose
Keep a small collection of videos and their comments, then print a clear summary for each one (title, author, length, comment count, and all comments).

### Class Diagram (ASCII)

+----------------------+
|        Video         |
+----------------------+
| - _title: string     |
| - _author: string    |
| - _lengthSeconds:int |
| - _comments: List<Comment> |
+----------------------+
| + Video(title: string, author: string, lengthSeconds: int) |
| + AddComment(comment: Comment): void |
| + GetCommentCount(): int              |
| + GetComments(): List<Comment>        |
| + GetTitle(): string                  |
| + GetAuthor(): string                 |
| + GetLengthSeconds(): int             |
+----------------------+

+----------------------+
|       Comment        |
+----------------------+
| - _commenterName:string |
| - _text: string         |
+----------------------+
| + Comment(commenterName: string, text: string) |
| + GetCommenterName(): string                   |
| + GetText(): string                            |
+----------------------+

### Responsibilities
- **Video**: Holds the video details, keeps the list of comments, and exposes the info we need to display.
- **Comment**: Stores who commented and what they said.

### Program Flow (High-Level)
1. Create a `List<Video>`.
2. Create four `Video` objects with these titles, authors, and lengths:
	- "Designing a Minimalist Home Office" by "Studio North" (512 seconds)
	- "10 Minute Pasta, No Fuss" by "Chef Mateo" (638 seconds)
	- "Trail Run Basics: Breathing and Form" by "Outdoor Steps" (905 seconds)
	- "How I Plan a Study Week" by "Campus Coach" (721 seconds)
3. Add comments to each video (3, 4, 3, and 3 comments respectively), then add each video to the list.
4. Loop through the list and print each video's title, author, length, comment count, and all comments.

---

## Program 2: Online Ordering (Encapsulation)

### Purpose
Build orders from products and customers, calculate the total with shipping, and print packing and shipping labels.

### Class Diagram (ASCII)

+----------------------+
|       Product        |
+----------------------+
| - _name: string         |
| - _productId: string    |
| - _pricePerUnit: decimal |
| - _quantity: int        |
+----------------------+
| + Product(name: string, productId: string, pricePerUnit: decimal, quantity: int) |
| + GetName(): string               |
| + GetProductId(): string          |
| + GetTotalCost(): decimal         |
+----------------------+

+----------------------+
|       Address        |
+----------------------+
| - _street: string    |
| - _city: string      |
| - _stateOrProvince: string |
| - _country: string   |
+----------------------+
| + Address(street: string, city: string, stateOrProvince: string, country: string) |
| + IsInUsa(): bool               |
| + GetFullAddress(): string      |
+----------------------+

+----------------------+
|       Customer       |
+----------------------+
| - _name: string      |
| - _address: Address  |
+----------------------+
| + Customer(name: string, address: Address) |
| + GetName(): string               |
| + GetAddress(): Address           |
| + LivesInUsa(): bool              |
+----------------------+

+----------------------+
|        Order         |
+----------------------+
| - _products: List<Product> |
| - _customer: Customer       |
+----------------------+
| + Order(customer: Customer)            |
| + AddProduct(product: Product): void   |
| + GetTotalCost(): decimal              |
| + GetPackingLabel(): string            |
| + GetShippingLabel(): string           |
| - GetShippingCost(): decimal           |
+----------------------+

### Responsibilities
- **Product**: Holds product info and calculates its total cost.
- **Address**: Stores the address, checks if it is in the USA, and formats the full address.
- **Customer**: Stores the customer name and address, and checks whether they live in the USA.
- **Order**: Keeps the products and customer, calculates the total including shipping, and builds the labels.

### Program Flow (High-Level)
1. Create a `List<Order>`.
2. Create the first order with a USA customer:
	- Address: "1250 Harbor Lane", "Seattle", "WA", "USA"
	- Customer: "Maya Thompson"
	- Products: "Wireless Mouse" (WM-204, 24.99 x2), "Mechanical Keyboard" (KB-873, 129.50 x1), "USB-C Cable" (UC-115, 9.75 x3)
3. Create the second order with an international customer:
	- Address: "88 Pine Street", "Vancouver", "BC", "Canada"
	- Customer: "Oliver Chen"
	- Products: "Stainless Steel Bottle" (BT-442, 18.25 x2), "Insulated Lunch Bag" (LB-902, 21.40 x1)
4. Loop through orders and print the packing label, shipping label, and total cost for each order.
