print("Welcome to the Probability Distribution Identifier.")


choice = input("Is the distribution Uniform? (y/n) ").lower()

if choice == "y":
    print("Continuous Uniform\nmean: (a+b)/2\nstan.dev.: ((b-a)^2)/12")

elif choice == "n":
    choice = input("Is the distribution Normal? (y/n)? ").lower()
    
    if choice == "y":
        print("Normal Distribution\nmean: mu\nstan.dev.: sigma")
    
    elif choice == "n":
        choice = input ("Bernoulli (B) or Poisson (P)?").lower()

        if choice == "b":
            choice = input("With (W) or Without (O) replacement?").lower()

            if choice == "w":
                choice == input("Fixed (F) or Variable (V) number of trials?").lower()

                if choice == "f":
                    choice == input("Dichotomous (D) or Multiple (M) outcomes?").lower()

                    if choice == "d":
                        print("Binomial\nmean: n*p\nstan.dev.: n*p*q")
                    
                    elif choice == "m":
                        print("Multinomial\nmean: n*p_i\nstan.dev: n*p_i*(1-p_i)")

                    else:
                        print("Invalid input. Please try again.")
                    
                elif choice == "v":
                    choice = input("Multiple (M) or First (F) success?").lower()

                    if choice == "m":
                        print("Negative Binomial\nmean: k/p\nstan.dev.: (k*(1-p))/p^2")

                    elif choice == "f":
                        print("Geometric\nmean: 1/p\nstan.dev.: (1-p)/p^2")
                    
                    else:
                        print("Invalid input. Please try again.")
                
                else:
                    print("Invalid input. Please try again.")
                
            elif choice == "o":
                choice == input("Dichotomous (D) or Multiple (M) outcomes?").lower()

                if choice == "d":
                    print("Hypergeometric\nmean: (n*k)/N \nstan.dev.: (N-n)/(N-1) * n * k/N*(1-k/N)")
                
                elif choice == "m":
                    print("Mutivariate Hypergeometric\nmean: n*(K_i/N)\nstan.dev.: n*(N-n)/(N-1) * K_i/N * (1 - K_i/N)")

                else:
                    print("Invalid input. Please try again.")

            else:
                print("Invalid input. Please try again.")
        elif choice == "p":
            choice = input("Occurrences per Interval (O) or Interval between Occurrences (I)")

            if choice == "o":
                print("Poisson\nmean: lambda*t\nstan.dev.: lambda*t")

            elif choice == "i":
                print("Exponential\nmean: beta\nstan.dev.: beta")

            else:
                print("Invalid input. Please try again.")
        else:
            print("Invalid input. Please try again.")
            
    else:
        print("Invalid input. Please try again.")

else:
    print("Invalid input. Please try again.")