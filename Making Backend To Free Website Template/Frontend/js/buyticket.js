document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("ticketForm").addEventListener("submit", async function (event) {
        event.preventDefault(); // Prevent the default form submission

        const fullName = document.getElementById("ticket-form-name")?.value.trim();
        const email = document.getElementById("ticket-form-email")?.value.trim();
        const phoneNumber = document.getElementById("ticket-form-phone")?.value.trim();
        const numberOfTickets = document.getElementById("ticket-form-number")?.value.trim();
        const additionalRequest = document.getElementById("ticket-form-message")?.value.trim();
        const ticketTypeValue = document.querySelector('input[name="TicketFormRadio"]:checked')?.value;

        // Map ticket type to integer values (use the numeric enum values from C#)
        const ticketTypeMap = {
            "1": 1,  // EarlyBird
            "2": 2   // Standart
        };

        // Prepare the data to send in the request
        const data = {
            FullName: fullName,
            Email: email,
            PhoneNumber: phoneNumber,
            TicketType: ticketTypeMap[ticketTypeValue],  // Send numeric value for TicketType (1 or 2)
            NumberOfTickets: parseInt(numberOfTickets, 10),
            AdditionalRequest: additionalRequest
        };

        // Log the data to see if it's structured correctly
        console.log("Data to send:", JSON.stringify(data));

        try {
            const response = await fetch("http://localhost:5127/ticket", {
                method: "POST",
                headers: {
                    "Accept": "*/*",
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(data)  // Send the data as JSON
            });

            if (response.ok) {
                const result = await response.json();
                alert("Ticket booked successfully!");
                console.log(result);
            } else {
                const errorText = await response.text();
                alert("Error booking ticket: " + errorText);
            }
        } catch (error) {
            console.error("Request failed", error);
            alert("An error occurred while sending the request.");
        }
    });
});
