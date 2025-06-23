-- This SQL script inserts sample data into the Order Management database schema. (AI- generated sample data)
-- Insert sample customers
INSERT INTO customers (first_name, last_name, email, phone, address, city, state, pincode_code) VALUES
('John', 'Smith', 'john.smith@email.com', '555-0101', '123 Main St', 'New York', 'NY', '10001'),
('Sarah', 'Johnson', 'sarah.johnson@email.com', '555-0102', '456 Oak Ave', 'Los Angeles', 'CA', '90210'),
('Michael', 'Brown', 'michael.brown@email.com', '555-0103', '789 Pine Rd', 'Chicago', 'IL', '60601'),
('Emily', 'Davis', 'emily.davis@email.com', '555-0104', '321 Elm St', 'Houston', 'TX', '77001'),
('David', 'Wilson', 'david.wilson@email.com', '555-0105', '654 Maple Dr', 'Phoenix', 'AZ', '85001');

-- Insert sample products
INSERT INTO products (product_name, description, category, price, stock_quantity) VALUES
('Wireless Headphones', 'High-quality Bluetooth headphones with noise cancellation', 'Electronics', 199.99, 50),
('Smartphone Case', 'Protective case for latest smartphone models', 'Accessories', 29.99, 100),
('Coffee Maker', 'Programmable drip coffee maker with thermal carafe', 'Home & Kitchen', 89.99, 25),
('Running Shoes', 'Lightweight running shoes with cushioned sole', 'Sports', 129.99, 75),
('Laptop Stand', 'Adjustable aluminum laptop stand for ergonomic use', 'Office', 49.99, 40),
('Water Bottle', 'Insulated stainless steel water bottle', 'Sports', 24.99, 80),
('Desk Lamp', 'LED desk lamp with adjustable brightness', 'Office', 39.99, 30),
('Bluetooth Speaker', 'Portable wireless speaker with premium sound', 'Electronics', 79.99, 45);

-- Insert sample orders with dates from the last 45 days
INSERT INTO orders (customer_id, order_date, status, total_amount, shipping_address) VALUES
(1, DATEADD(DAY, -5, GETDATE()), 'delivered', 229.98, '123 Main St, New York, NY 10001'),
(2, DATEADD(DAY, -10, GETDATE()), 'shipped', 159.98, '456 Oak Ave, Los Angeles, CA 90210'),
(1, DATEADD(DAY, -15, GETDATE()), 'delivered', 89.99, '123 Main St, New York, NY 10001'),
(3, DATEADD(DAY, -20, GETDATE()), 'processing', 179.98, '789 Pine Rd, Chicago, IL 60601'),
(4, DATEADD(DAY, -25, GETDATE()), 'delivered', 54.98, '321 Elm St, Houston, TX 77001'),
(2, DATEADD(DAY, -30, GETDATE()), 'delivered', 104.98, '456 Oak Ave, Los Angeles, CA 90210'),
(5, DATEADD(DAY, -35, GETDATE()), 'cancelled', 199.99, '654 Maple Dr, Phoenix, AZ 85001'),
(1, DATEADD(DAY, -40, GETDATE()), 'delivered', 79.99, '123 Main St, New York, NY 10001'),
(3, DATEADD(DAY, -8, GETDATE()), 'shipped', 69.98, '789 Pine Rd, Chicago, IL 60601'),
(4, DATEADD(DAY, -12, GETDATE()), 'delivered', 149.99, '321 Elm St, Houston, TX 77001');

-- Insert order items
INSERT INTO order_items (order_id, product_id, quantity, unit_price, subtotal) VALUES
-- Order 1 (John Smith - $229.98)
(1, 1, 1, 199.99, 199.99),
(1, 2, 1, 29.99, 29.99),
-- Order 2 (Sarah Johnson - $159.98)
(2, 4, 1, 129.99, 129.99),
(2, 2, 1, 29.99, 29.99),
-- Order 3 (John Smith - $89.99)
(3, 3, 1, 89.99, 89.99),
-- Order 4 (Michael Brown - $179.98)
(4, 4, 1, 129.99, 129.99),
(4, 5, 1, 49.99, 49.99),
-- Order 5 (Emily Davis - $54.98)
(5, 6, 1, 24.99, 24.99),
(5, 2, 1, 29.99, 29.99),
-- Order 6 (Sarah Johnson - $104.98)
(6, 8, 1, 79.99, 79.99),
(6, 6, 1, 24.99, 24.99),
-- Order 7 (David Wilson - $199.99) - Cancelled
(7, 1, 1, 199.99, 199.99),
-- Order 8 (John Smith - $79.99)
(8, 8, 1, 79.99, 79.99),
-- Order 9 (Michael Brown - $69.98)
(9, 7, 1, 39.99, 39.99),
(9, 2, 1, 29.99, 29.99),
-- Order 10 (Emily Davis - $149.99)
(10, 4, 1, 129.99, 129.99),
(10, 6, 1, 24.99, 24.99);

-- Insert payments
INSERT INTO payments (order_id, payment_method, payment_status, amount, transaction_id) VALUES
(1, 'credit_card', 'completed', 229.98, 'TXN001'),
(2, 'upi', 'completed', 159.98, 'TXN002'),
(3, 'credit_card', 'completed', 89.99, 'TXN003'),
(4, 'debit_card', 'completed', 179.98, 'TXN004'),
(5, 'credit_card', 'completed', 54.98, 'TXN005'),
(6, 'upi', 'completed', 104.98, 'TXN006'),
(7, 'credit_card', 'refunded', 199.99, 'TXN007'),
(8, 'credit_card', 'completed', 79.99, 'TXN008'),
(9, 'bank_transfer', 'completed', 69.98, 'TXN009'),
(10, 'credit_card', 'completed', 149.99, 'TXN010');
