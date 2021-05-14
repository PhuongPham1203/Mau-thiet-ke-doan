public class Client {

    public static void main(String args[]) {
        System.out.println("2 cong 2 = " + interpret("2 cong 2"));
        // System.out.println("10 tru 4 = " + interpret("10 tru 4"));
        System.out.println("2 mu 3 = " + interpret("2 mu 3"));
        System.out.println("can 4 = " + interpret("can 4"));
    }

    private static int interpret(String input) {
        Expression exp = null;
        if (input.contains("cong")) {
            exp = new AddExpression(input);
        } else if (input.contains("tru")) {
            exp = new SubtractExpression(input);
        } else if (input.contains("mu")) {
            exp = new PowerExpression(input);
        } else if (input.contains("can")) {
            exp = new SquareExpression(input);
        } else {
            throw new UnsupportedOperationException();
        }
        return exp.interpret(new InterpreterEngineContext());
    }
}