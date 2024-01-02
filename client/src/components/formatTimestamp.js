export function formatTimestamp(timestamp) {

  const date = new Date(timestamp);


  const monthNames = [
    "Jan", "Feb", "Mar", "Apr", "May", "Jun",
    "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
  ];
  const month = monthNames[date.getMonth()];
  const day = date.getDate();
  const year = date.getFullYear();
  let hours = date.getHours();
  const ampm = hours >= 12 ? 'pm' : 'am';

  // Convert hours to 12-hour format
  hours = hours % 12;
  hours = hours ? hours : 12; // If hours is 0, set it to 12

  // Get minutes and pad with leading zero if needed
  const minutes = ('0' + date.getMinutes()).slice(-2);

  // Construct the formatted string
  const formattedDate = `${month} ${day}, ${year}\n${hours}:${minutes} ${ampm}`;

  return formattedDate;
}