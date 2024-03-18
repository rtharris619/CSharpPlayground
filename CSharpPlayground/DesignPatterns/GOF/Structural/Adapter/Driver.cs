/* In this example, the PayPalAdapter and StripeAdapter classes adapt the 
* interfaces of the PayPal and Stripe payment services, respectively, 
* to the IPaymentGateway interface expected by your application. 
* This allows your application to support multiple payment gateways seamlessly, 
* facilitating easy integration and expansion with minimal changes to the core application code. */

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Adapter
{
    public static class Driver
    {
        public static void Run()
        {
            IPaymentGateway payPalGateway = new PayPalAdapter(new PayPal());
            IPaymentGateway stripeGateway = new StripeAdapter(new Stripe());

            PaymentProcessor paymentProcessor = new PaymentProcessor();

            paymentProcessor.ProcessPayment(payPalGateway, "1234", 100.00m);

            paymentProcessor.ProcessPayment(stripeGateway, "5678", 200.00m);
        }
    }
}
