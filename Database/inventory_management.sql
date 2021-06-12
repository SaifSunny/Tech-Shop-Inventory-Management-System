-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 12, 2021 at 10:49 AM
-- Server version: 10.4.13-MariaDB
-- PHP Version: 7.2.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `inventory_management`
--

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`category_id`, `category_name`) VALUES
(3, 'Computer'),
(14, 'Electronics'),
(2, 'Laptop'),
(1, 'Mobile'),
(7, 'Refrigerator'),
(6, 'Television'),
(5, 'Washing Machine');

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `customer_id` int(11) NOT NULL,
  `customer_name` varchar(80) NOT NULL,
  `address` varchar(80) NOT NULL,
  `city` varchar(80) NOT NULL,
  `zip` varchar(20) NOT NULL,
  `phone` varchar(80) DEFAULT NULL,
  `email` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`customer_id`, `customer_name`, `address`, `city`, `zip`, `phone`, `email`) VALUES
(1001, 'Dinabandhu  Dutta', 'House - 2, road 1,Dhanmondi, ', 'Dhaka', '1205', '880 011 90654275', 'Dinabandhu12@gmail.com'),
(1003, 'Rahmat Khan', 'Rokeya Palace(4th Floor), Mohammadpur', 'Dhaka', '1207', '880 011 10611275', 'khan1112@gmail.com'),
(1004, 'Pria Khan', 'House - 5, road 5,Dhanmondi, ', 'Dhaka', '1205', '880 011 90654285', 'priya312@gmail.com'),
(1005, 'Rahima Khan', 'New DOHS, Mohakhali, Dhaka Cantonment', 'Dhaka ', '1206', '01719885025', 'rahima12@cosmetic.org'),
(1006, 'Sadia Afrin', '2-11 A Block -D, Lalmatia', 'Dhaka ', ' 1207', '01714485025', 'home@.org.bd');

-- --------------------------------------------------------

--
-- Table structure for table `manager`
--

CREATE TABLE `manager` (
  `manager_id` int(11) NOT NULL,
  `username` varchar(80) NOT NULL,
  `password` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `manager`
--

INSERT INTO `manager` (`manager_id`, `username`, `password`) VALUES
(1, 'sunny', 'sunny123'),
(2, 'pinky', 'pinky123');

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `order` (
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `customer_name` varchar(80) NOT NULL,
  `product_name` varchar(80) NOT NULL,
  `category_name` varchar(80) DEFAULT NULL,
  `selling_price` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `order_date` date DEFAULT NULL,
  `delivery_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `order`
--

INSERT INTO `order` (`order_id`, `product_id`, `customer_id`, `category_id`, `customer_name`, `product_name`, `category_name`, `selling_price`, `quantity`, `order_date`, `delivery_date`) VALUES
(20023, 10004, 1003, 1, 'Rahmat Khan', 'Xiaomi Mi 11', 'Mobile', 40000, 1, '2021-01-09', '2021-01-10'),
(20024, 10006, 1003, 2, 'Rahmat Khan', 'Lenovo Ideapad S145 81N300F8IN AMD A6-9225 Laptop', 'Laptop', 30000, 3, '2021-01-13', '2021-01-19'),
(20026, 10005, 1003, 1, 'Rahmat Khan', 'OnePlus 2', 'Mobile', 28000, 1, '2021-01-12', '2021-01-15'),
(20028, 10009, 1006, 7, 'Sadia Afrin', 'Refrigerator 333 Ltr Singer Marble Black. Model: SRREF-SINGER-BCD-333R-MBG.', 'Refrigerator', 30000, 1, '2021-01-22', '2021-01-29');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `product_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `product_name` varchar(80) NOT NULL,
  `category_name` varchar(80) DEFAULT NULL,
  `stock_quantity` int(11) NOT NULL,
  `original_price` int(11) NOT NULL,
  `received_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`product_id`, `category_id`, `product_name`, `category_name`, `stock_quantity`, `original_price`, `received_date`) VALUES
(10002, 6, 'Samsung 75\" Crystal UHD 4K Smart TV', 'Television', 15, 200000, '2021-01-05'),
(10003, 1, 'Oppo Reno5 4G', 'Mobile', 19, 27000, '2021-01-05'),
(10004, 1, 'Xiaomi Mi 11', 'Mobile', 10, 52000, '2021-01-05'),
(10005, 1, 'OnePlus 2', 'Mobile', 15, 20000, '2021-01-05'),
(10006, 2, 'Lenovo Ideapad S145 81N300F8IN AMD A6-9225 Laptop', 'Laptop', 9, 25000, '2021-01-05'),
(10007, 2, 'Lenovo Ideapad S145 (81VD00DWIN) 8TH GEN CORE i3 ', 'Laptop', 20, 37000, '2021-01-05'),
(10008, 7, 'Walton WFD-1B6-GDEL-XX Frost Refrigerator - 132 Ltr.', 'Refrigerator', 9, 14000, '2021-01-05'),
(10009, 7, 'Refrigerator 333 Ltr Singer Marble Black. Model: SRREF-SINGER-BCD-333R-MBG.', 'Refrigerator', 10, 24000, '2021-01-05'),
(10013, 1, 'Oppo Reno5 4G22', 'Mobile', 20, 27000, '2021-01-05'),
(10017, 3, 'HP 4K 8gb ram', 'Computer', 5, 30000, '2021-01-09');

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `customer_name` varchar(80) NOT NULL,
  `product_name` varchar(80) NOT NULL,
  `original_price` int(11) NOT NULL,
  `selling_price` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `original_total` int(11) NOT NULL,
  `selling_total` int(11) NOT NULL,
  `order_date` date NOT NULL,
  `delivery_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`order_id`, `product_id`, `customer_id`, `customer_name`, `product_name`, `original_price`, `selling_price`, `quantity`, `original_total`, `selling_total`, `order_date`, `delivery_date`) VALUES
(20001, 10008, 1003, 'Rahmat Khan', 'Walton WFD-1B6-GDEL-XX Frost Refrigerator - 132 Ltr.', 14000, 25000, 1, 14000, 25000, '2021-01-09', '2021-01-14'),
(20005, 10003, 1001, 'Dinabandhu  Dutt', 'Oppo Reno5 4G', 27000, 39000, 1, 27000, 39000, '2021-01-10', '2021-01-12'),
(20025, 10006, 1004, 'Pria Khan', 'Lenovo Ideapad S145 81N300F8IN AMD A6-9225 Laptop', 25000, 30000, 1, 25000, 30000, '2021-01-13', '2021-01-19'),
(20027, 10005, 1006, 'Sadia Afrin', 'OnePlus 2', 20000, 28000, 2, 40000, 56000, '2021-01-19', '2021-01-21'),
(20029, 10005, 1006, 'Sadia Afrin', 'OnePlus 2', 20000, 28000, 3, 60000, 84000, '2021-01-14', '2021-01-14');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`category_id`),
  ADD UNIQUE KEY `category_name` (`category_name`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`customer_id`);

--
-- Indexes for table `manager`
--
ALTER TABLE `manager`
  ADD PRIMARY KEY (`manager_id`);

--
-- Indexes for table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `customer_id` (`customer_id`),
  ADD KEY `category_id` (`category_id`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`product_id`),
  ADD UNIQUE KEY `product_name` (`product_name`),
  ADD KEY `category_id` (`category_id`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD UNIQUE KEY `order_id_2` (`order_id`),
  ADD KEY `order_id` (`order_id`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `customer_id` (`customer_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1008;

--
-- AUTO_INCREMENT for table `manager`
--
ALTER TABLE `manager`
  MODIFY `manager_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `order`
--
ALTER TABLE `order`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20030;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10019;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `order_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`),
  ADD CONSTRAINT `order_ibfk_2` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`customer_id`),
  ADD CONSTRAINT `order_ibfk_3` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`);

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`);

--
-- Constraints for table `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`customer_id`),
  ADD CONSTRAINT `sales_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
