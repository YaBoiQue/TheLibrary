CREATE VIEW `transactiontotals` AS
SELECT t.*, SUM(ti.Price * ti.Count)
FROM transactions t, transactionitems ti