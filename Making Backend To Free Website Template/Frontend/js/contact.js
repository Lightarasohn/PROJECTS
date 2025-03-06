document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("contactForm").addEventListener("submit", async function (event) {
        event.preventDefault(); // Formun varsayılan submit işlemini engelle

        const formData = {
            FullName: document.getElementById("contact-name").value.trim(),
            Email: document.getElementById("contact-email").value.trim(),
            Company: document.getElementById("contact-company").value.trim(),
            Message: document.getElementById("contact-message").value.trim()
        };

        try {
            const response = await fetch("http://localhost:5127/contact", {
                method: "POST",
                headers: {
                    "Accept": "*/*",
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(formData)
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
