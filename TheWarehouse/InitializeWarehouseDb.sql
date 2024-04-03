-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema warehousedb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema warehousedb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `warehousedb` DEFAULT CHARACTER SET utf8mb3 ;
USE `warehousedb` ;

-- -----------------------------------------------------
-- Table `warehousedb`.`menucategories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`menucategories` (
  `MenucategoryId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`MenucategoryId`),
  UNIQUE INDEX `idMenucategories_UNIQUE` (`MenucategoryId` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`menuitems`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`menuitems` (
  `MenuItemId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `Price` DECIMAL(5,2) NULL DEFAULT NULL,
  `MenucategoryId` INT NULL DEFAULT NULL,
  `Active` BIT NOT NULL DEFAULT 0 COMMENT 'Bit value represents boolean\n0 = true\n1 = false',
  `created_ts` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_ts` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_userId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  `updated_userId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  PRIMARY KEY (`MenuItemId`),
  UNIQUE INDEX `idMenuItems_UNIQUE` (`MenuItemId` ASC) VISIBLE,
  INDEX `Menucategory_idx` (`MenucategoryId` ASC) VISIBLE,
  INDEX `MenuItems_CreatedUser_idx` (`created_userId` ASC) VISIBLE,
  INDEX `MenuItems_UpdatedUser_idx` (`updated_userId` ASC) VISIBLE,
  CONSTRAINT `MenuItems_Menucategory`
    FOREIGN KEY (`MenucategoryId`)
    REFERENCES `warehousedb`.`menucategories` (`MenucategoryId`),
  CONSTRAINT `MenuItems_CreatedUser`
    FOREIGN KEY (`created_userId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `MenuItems_UpdatedUser`
    FOREIGN KEY (`updated_userId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`suppliers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`suppliers` (
  `SupplierId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `created_ts` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_ts` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_userId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  `udated_userId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  PRIMARY KEY (`SupplierId`),
  UNIQUE INDEX `idSuppliers_UNIQUE` (`SupplierId` ASC) VISIBLE,
  INDEX `Suppliers_CreatedUser_idx` (`created_userId` ASC) VISIBLE,
  INDEX `Suppliers_UpdatedUser_idx` (`udated_userId` ASC) VISIBLE,
  CONSTRAINT `Suppliers_CreatedUser`
    FOREIGN KEY (`created_userId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `Suppliers_UpdatedUser`
    FOREIGN KEY (`udated_userId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`supplycategories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`supplycategories` (
  `SupplycategoryId` INT NOT NULL,
  `Name` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  PRIMARY KEY (`SupplycategoryId`),
  UNIQUE INDEX `idSupplycategory_UNIQUE` (`SupplycategoryId` ASC) VISIBLE,
  UNIQUE INDEX `Name_UNIQUE` (`Name` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`supplies`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`supplies` (
  `SupplyId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `SupplyCategoryId` INT NOT NULL,
  `SupplierId` INT NULL DEFAULT NULL,
  `created_ts` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_ts` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_userId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  `updated_userId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  PRIMARY KEY (`SupplyId`),
  UNIQUE INDEX `idSupplies_UNIQUE` (`SupplyId` ASC) VISIBLE,
  INDEX `Supplies_Suppliers_idx` (`SupplierId` ASC) VISIBLE,
  INDEX `Supplycategory_idx` (`SupplyCategoryId` ASC) VISIBLE,
  INDEX `Supplies_UpdatedUser_idx` (`updated_userId` ASC) VISIBLE,
  INDEX `Supplies_CreatedUser_idx` (`created_userId` ASC) VISIBLE,
  CONSTRAINT `Supplies_Suppliers`
    FOREIGN KEY (`SupplierId`)
    REFERENCES `warehousedb`.`suppliers` (`SupplierId`),
  CONSTRAINT `Supplies_Supplycategories`
    FOREIGN KEY (`SupplyCategoryId`)
    REFERENCES `warehousedb`.`supplycategories` (`SupplycategoryId`),
  CONSTRAINT `Supplies_UpdatedUser`
    FOREIGN KEY (`updated_userId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `Supplies_CreatedUser`
    FOREIGN KEY (`created_userId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`ingredients`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`ingredients` (
  `IngredientId` INT NOT NULL AUTO_INCREMENT,
  `MenuItemId` INT NOT NULL,
  `SupplyId` INT NOT NULL,
  `created_ts` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_ts` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_userId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  `updated_userId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  PRIMARY KEY (`IngredientId`),
  UNIQUE INDEX `idIngredients_UNIQUE` (`IngredientId` ASC) VISIBLE,
  INDEX `MenuItems_idx` (`MenuItemId` ASC) VISIBLE,
  INDEX `Supplies_idx` (`SupplyId` ASC) VISIBLE,
  INDEX `Ingredients_CreatedUser_idx` (`created_userId` ASC) VISIBLE,
  INDEX `Ingredients_UpdatedUser_idx` (`updated_userId` ASC) VISIBLE,
  CONSTRAINT `Ingredients_MenuItems`
    FOREIGN KEY (`MenuItemId`)
    REFERENCES `warehousedb`.`menuitems` (`MenuItemId`),
  CONSTRAINT `Ingredients_Supplies`
    FOREIGN KEY (`SupplyId`)
    REFERENCES `warehousedb`.`supplies` (`SupplyId`),
  CONSTRAINT `Ingredients_CreatedUser`
    FOREIGN KEY (`created_userId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `Ingredients_UpdatedUser`
    FOREIGN KEY (`updated_userId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`stockcodes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`stockcodes` (
  `Code` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `Description` MEDIUMTEXT CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  PRIMARY KEY (`Code`),
  UNIQUE INDEX `Code_UNIQUE` (`Code` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`stocks`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`stocks` (
  `StockId` INT NOT NULL AUTO_INCREMENT,
  `SupplyId` INT NOT NULL,
  `Count` INT NOT NULL DEFAULT '1',
  `Price` DECIMAL(6,2) NULL DEFAULT NULL,
  `UserId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  `Code` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `timestamp` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`StockId`),
  UNIQUE INDEX `idStock_UNIQUE` (`StockId` ASC) VISIBLE,
  INDEX `Stock_Stockcodes_idx` (`Code` ASC) VISIBLE,
  INDEX `Supplies_idx1` (`SupplyId` ASC) VISIBLE,
  INDEX `Stock_Users_idx` (`UserId` ASC) VISIBLE,
  CONSTRAINT `Stock_Stockcodes`
    FOREIGN KEY (`Code`)
    REFERENCES `warehousedb`.`stockcodes` (`Code`),
  CONSTRAINT `Stock_Supplies`
    FOREIGN KEY (`SupplyId`)
    REFERENCES `warehousedb`.`supplies` (`SupplyId`),
  CONSTRAINT `Stock_Users`
    FOREIGN KEY (`UserId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`transactioncodes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`transactioncodes` (
  `Code` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `Description` MEDIUMTEXT CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  PRIMARY KEY (`Code`),
  UNIQUE INDEX `Code_UNIQUE1` (`Code` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`transactions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`transactions` (
  `TransactionId` INT NOT NULL AUTO_INCREMENT,
  `Code` VARCHAR(45) NULL DEFAULT NULL,
  `timestamp` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UserId` VARCHAR(255) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  PRIMARY KEY (`TransactionId`),
  UNIQUE INDEX `idTransactions_UNIQUE` (`TransactionId` ASC) VISIBLE,
  INDEX `Transactions_TransactionCodes_idx` (`Code` ASC) VISIBLE,
  INDEX `Transactions_Users_idx` (`UserId` ASC) VISIBLE,
  CONSTRAINT `Transactions_TransactionCodes`
    FOREIGN KEY (`Code`)
    REFERENCES `warehousedb`.`transactioncodes` (`Code`),
  CONSTRAINT `Transactions_Users`
    FOREIGN KEY (`UserId`)
    REFERENCES `identitydb`.`aspnetuser` (`Id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `warehousedb`.`transactionitems`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `warehousedb`.`transactionitems` (
  `TransactionItemId` INT NOT NULL AUTO_INCREMENT,
  `TransactionId` INT NOT NULL,
  `MenuItemId` INT NOT NULL,
  `Count` INT NOT NULL DEFAULT '1',
  `Price` DOUBLE(6,2) NOT NULL,
  `timestamp` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`TransactionItemId`),
  UNIQUE INDEX `idSales_UNIQUE` (`TransactionItemId` ASC) VISIBLE,
  INDEX `MenuItems_idx1` (`MenuItemId` ASC) VISIBLE,
  INDEX `Transactions_idx` (`TransactionId` ASC) VISIBLE,
  CONSTRAINT `TransactionItems_MenuItems`
    FOREIGN KEY (`MenuItemId`)
    REFERENCES `warehousedb`.`menuitems` (`MenuItemId`),
  CONSTRAINT `TransactionItems_Transactions`
    FOREIGN KEY (`TransactionId`)
    REFERENCES `warehousedb`.`transactions` (`TransactionId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
