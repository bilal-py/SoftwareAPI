
-- Customers table
CREATE TABLE customers (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    phone NVARCHAR(20),
    address NVARCHAR(MAX),
    city NVARCHAR(50),
    customer_state NVARCHAR(50),
    pin_code NVARCHAR(10),
    created_at DATETIME2 DEFAULT GETDATE()
);

-- Products table
CREATE TABLE products (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_name NVARCHAR(100) NOT NULL,
    description NVARCHAR(MAX),
    category NVARCHAR(50),
    price DECIMAL(10, 2) NOT NULL,
    stock_quantity INT DEFAULT 0,
    created_at DATETIME2 DEFAULT GETDATE()
);

-- Orders table
CREATE TABLE orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATETIME2 DEFAULT GETDATE(),
    status NVARCHAR(20) CHECK (status IN ('pending', 'processing', 'shipped', 'delivered', 'cancelled')) DEFAULT 'pending',
    total_amount DECIMAL(10, 2) NOT NULL,
    shipping_address NVARCHAR(MAX),
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id) ON DELETE CASCADE
);

-- Order Items table 
CREATE TABLE order_items (
    order_item_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(10, 2) NOT NULL,
    subtotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(order_id) ON DELETE CASCADE,
    FOREIGN KEY (product_id) REFERENCES products(product_id) ON DELETE CASCADE
);

-- Payments table
CREATE TABLE payments (
    payment_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL,
    payment_method NVARCHAR(20) CHECK (payment_method IN ('credit_card', 'debit_card', 'upi', 'cash')) NOT NULL,
    payment_status NVARCHAR(20) CHECK (payment_status IN ('pending', 'completed', 'failed', 'refunded')) DEFAULT 'pending',
    amount DECIMAL(10, 2) NOT NULL,
    payment_date DATETIME2 DEFAULT GETDATE(),
    transaction_id NVARCHAR(100),
    FOREIGN KEY (order_id) REFERENCES orders(order_id) ON DELETE CASCADE
);