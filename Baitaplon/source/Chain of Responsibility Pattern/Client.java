
public class Client {
 
    public static void main(String[] args) {
        // * Tạo chain of responsibility
        Logger logger = AppLogger.getLogger();
 
        // * thử log ở mức độ Debug
        System.out.println("Log level Console");
        //logger.log(LogLevel.INFO, "Info message");
        logger.log(LogLevel.DEBUG, "Debug message");
 
        // * thử log ở mức độ Error
        System.out.println("----\nLog level Error - loi");
        logger.log(LogLevel.ERROR, "Error message");
 
        // * thử log ở mức độ Fatal
        System.out.println("----\nLog level Fatal - cuc nguy hiem");
        logger.log(LogLevel.FATAL, "Factal message");
    }
}