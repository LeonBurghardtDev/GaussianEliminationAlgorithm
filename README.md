# Gaussian Elimination Algorithm

## Overview
This program implements the **Gaussian Elimination** algorithm, a fundamental method in linear algebra for solving systems of linear equations, determining matrix inverses, and calculating determinants.

The project is inspired by the teachings of **Stefan Harmeling** in the Linear Algebra lecture at TU Dortmund. It translates mathematical concepts into a practical and interactive tool with a graphical user interface (GUI) built in WPF (Windows Presentation Foundation).

## Features
- **Matrix Input:** Allows users to input a matrix and a right-hand side vector via a GUI.
- **Gaussian Elimination:** Automatically performs forward elimination and backward substitution to solve the system of equations.
- **Detailed Logs:** Displays step-by-step logs of the calculations, highlighting pivot operations, row eliminations, and the final solution.
- **Results Display:** Clearly shows the original matrix, the transformed matrix, the right-hand side vector, and the solution in a structured format inspired by LaTeX-style formatting.
- **Error Handling:** Validates user input and provides feedback if the system is unsolvable or invalid data is provided.

## How It Works (Mathematical Explanation)
The program implements the Gaussian Elimination algorithm in two main phases:

### 1. Forward Elimination
- **Goal:** Transform the input matrix into an upper triangular matrix.
- For each pivot column:
  1. Ensure the pivot element is non-zero (row swaps if necessary).
  2. Eliminate all entries below the pivot by subtracting suitable multiples of the pivot row.

### 2. Backward Substitution
- **Goal:** Solve for the unknowns starting from the last row.
- Starting from the last equation, substitute the known values into the equations above to solve for all variables.

**Example:** For the system \( Ax = b \), where:

\[
A = \begin{bmatrix} 2 & 1 \\ 1 & 3 \end{bmatrix}, \quad b = \begin{bmatrix} 8 \\ 13 \end{bmatrix}
\]

The program performs elimination to solve for \( x \).

## How to Use
1. **Input Matrix and Vector:**
   - Enter the matrix and right-hand side vector in the input fields provided in the GUI.
   - Alternatively, use the "Fill with Random Values" button to generate a random solvable system.

2. **Start the Calculation:**
   - Click the "Solve" button to begin the Gaussian Elimination process.
   - The program will validate your input, perform the calculations, and display the results.

3. **Review the Results:**
   - The original matrix, the transformed matrix, the solution vector, and detailed logs are displayed in the result window.

4. **Close the Result Window:**
   - Use the "OK" button to close the result window.

## Known Issues
While the program has been extensively tested, there may still be edge cases or unexpected errors. For example:
- Extremely large matrices or floating-point precision issues might lead to inaccuracies.
- Non-invertible matrices (singular matrices) will cause the program to throw exceptions.

If you encounter any bugs or errors, I would greatly appreciate it if you could report them.

## How to Report Issues
Feel free to reach out to me via my website: [Leon Burghardt](https://leon-burghardt.dev). Your feedback will help improve the tool for everyone!

## License
This program was developed by **Leon Burghardt** in 2024. All rights reserved.

---
Thank you for using this program! I hope it serves as a helpful tool for understanding and applying Gaussian Elimination in your studies or work.
